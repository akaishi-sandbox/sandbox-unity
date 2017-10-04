using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

using Grpc.Core;
using MagicOnion.Client;
using MagicOnion.Resolvers;

using MessagePack.Internal;
using System;
using System.IO;
using MessagePack;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button asyncsum;
    [SerializeField] UnityEngine.UI.Button stream;

    // Use this for initialization
    async void Start()
    {
        Debug.Log($"grpc start");
        MagicOnionClientRegistry<Sandbox.ConsoleServer.IMyFirstService>.Register((x, y) => new Sandbox.ConsoleServer.IMyFirstServiceClient(x, y));
        var channel = new Channel("127.0.0.1", 50051, ChannelCredentials.Insecure);
        // await channel.WaitForStateChangedAsync(ChannelState.Shutdown);
        var client = MagicOnionClient.Create<Sandbox.ConsoleServer.IMyFirstService>(channel);



        asyncsum?.onClick.AddListener(() =>   // c# 4?
        {
            Debug.Log($"grpc sumasync");
            var result = client.SumAsync(100, 200);
            result.Subscribe(
                s => Debug.Log($"result:{s}"),
                err => Debug.LogError($"sumasync err:{err}"));

        });

        stream?.onClick.AddListener(() =>   // c# 4?
        {
            Debug.Log($"grpc stream");
            var fb = new FlatBuffers.FlatBufferBuilder(1);
            var name = fb.CreateString("abcd");
            var user = Data.User.CreateUser(fb, 10, name);
            Data.User.FinishUserBuffer(fb, user);

            var data = fb.SizedByteArray();
            var b = new FlatBuffers.ByteBuffer(data);

            var u = Data.User.GetRootAsUser(b);

            var result = client.StreamingUser(u);
            result.Subscribe(
                s => Debug.Log($"result:{s}"),
                err => Debug.LogError($"sumasync err:{err}"));

        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}

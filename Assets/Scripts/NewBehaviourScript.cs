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
    [SerializeField] UnityEngine.UI.Button button;

    // Use this for initialization
    async void Start()
    {
        Debug.Log($"grpc start");
        MagicOnionClientRegistry<Sandbox.ConsoleServer.IMyFirstService>.Register((x, y) => new Sandbox.ConsoleServer.IMyFirstServiceClient(x, y));
        var channel = new Channel("127.0.0.1", 50051, ChannelCredentials.Insecure);
        // await channel.WaitForStateChangedAsync(ChannelState.Shutdown);
        var client = MagicOnionClient.Create<Sandbox.ConsoleServer.IMyFirstService>(channel);



        button?.onClick.AddListener(() =>   // c# 4?
        {
            Debug.Log($"grpc sumasync");
            var result = client.SumAsync(100, 200);
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

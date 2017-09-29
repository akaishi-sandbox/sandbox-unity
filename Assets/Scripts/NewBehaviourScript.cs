using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Grpc.Core;
using MagicOnion.Client;
using MagicOnion.Resolvers;

using MessagePack.Internal;
using System;
using System.IO;
using MessagePack;

public class NewBehaviourScript : MonoBehaviour
{
    internal static class InternalMemoryPool
    {
        [ThreadStatic]
        static byte[] buffer = null;

        public static byte[] GetBuffer()
        {
            if (buffer == null)
            {
                buffer = new byte[65536];
            }
            return buffer;
        }
    }
    public static ArraySegment<byte> SerializeUnsafe<T>(T obj, IFormatterResolver resolver)
    {
        if (resolver == null) resolver = MessagePack.Resolvers.StandardResolver.Instance;
        var formatter = resolver.GetFormatterWithVerify<T>();

        var buffer = InternalMemoryPool.GetBuffer();

        var len = formatter.Serialize(ref buffer, 0, obj, resolver);

        // return raw memory pool, unsafe!
        return new ArraySegment<byte>(buffer, 0, len);
    }
    static System.Func<string, int, int> consturtor;

    // Use this for initialization
    async void Start()
    {
        Debug.Log($"grpc start");
        MagicOnionClientRegistry<Sandbox.ConsoleServer.IMyFirstService>.Register((x, y) => new Sandbox.ConsoleServer.IMyFirstServiceClient(x, y));
        var channel = new Channel("127.0.0.1", 50051, ChannelCredentials.Insecure);
        // await channel.WaitForStateChangedAsync(ChannelState.Shutdown);
        var client = MagicOnionClient.Create<Sandbox.ConsoleServer.IMyFirstService>(channel);

        Debug.Log($"grpc sumasync");
        var result = client.SumAsync(100, 200);
        Debug.Log($"result:{result}");

    }

    // Update is called once per frame
    void Update()
    {

    }
}

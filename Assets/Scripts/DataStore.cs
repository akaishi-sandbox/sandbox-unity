using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore : Singleton<DataStore>
{

    string savePath => $"{Application.persistentDataPath}/data.bin";

    readonly Dictionary<Type, Lazy<FlatBuffers.Table>> data = new Dictionary<Type, Lazy<FlatBuffers.Table>>();

    public void Register<T>() where T : FlatBuffers.Table
    {

        data[typeof(T)] = new Lazy<FlatBuffers.Table>(() =>
        {
            var buf = System.IO.File.ReadAllBytes(savePath);
            var b = new FlatBuffers.ByteBuffer(buf);
            return Data.User.GetRootAsUser(b);
        });

    }

    void init<T>() where T : FlatBuffers.Table
    {
        var builder = new FlatBuffers.FlatBufferBuilder(1);
        var user = Data.User.CreateUser(builder, 1, builder.CreateString("abcd"));
    }

    public T Get<T>() where T : FlatBuffers.Table
    {
        Lazy<FlatBuffers.Table> store;
        if (data.TryGetValue(typeof(T), out store))
        {
            return store.Value as T;
        }

        return null;
    }
    public void Save()
    {
        var builder = new FlatBuffers.FlatBufferBuilder(1);
        var user = Data.User.CreateUser(builder, 1, builder.CreateString("abcd"));
        Data.User.FinishUserBuffer(builder, user);

        System.IO.File.WriteAllBytes(savePath, builder.SizedByteArray());
    }
}

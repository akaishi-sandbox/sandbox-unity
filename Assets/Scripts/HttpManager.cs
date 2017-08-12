using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

using UniRx;

using System.Net;
using System.Net.Sockets;

public class HttpManager : Singleton<HttpManager>
{

    public async Task<WWW> WWW()
    {
        var www = await new WWW("https://redstone.biz");

        return www;

    }

    void aaaa()
    {
        var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        var endpoint = new IPEndPoint(0, 0);
        client.BeginConnect(endpoint, (res) =>
        {
            // callback
        }, null);
    }
}

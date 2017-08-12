using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.Net.Sockets;

public class HttpManager : Singleton<HttpManager>
{

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

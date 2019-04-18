using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

using UniRx;
using UniRx.Async;

using System.Net;
using System.Net.Sockets;

public class HttpManager : Singleton<HttpManager>
{

    public async Task<UnityEngine.Networking.UnityWebRequest> WWW(string url)
    {
        try
        {
            var request = UnityEngine.Networking.UnityWebRequest.Get(url);
            await request.SendWebRequest();

            return request;
        }
        catch (WWWErrorException)
        {

        }

        return null;

    }

    void aaaa()
    {
        // var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // var endpoint = new IPEndPoint(0, 0);
        // client.BeginConnect(endpoint, (res) =>
        // {
        //     // callback
        // }, null);
    }
}

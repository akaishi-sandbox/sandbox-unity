using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

using UniRx;

using System.Net;
using System.Net.Sockets;

public class HttpManager : Singleton<HttpManager>
{

    public async Task<WWW> WWW(string url)
    {
        var www = await new WWW(url);

        return www;

    }

    public async Task<WWW> ObWWW(string url)
    {
        try
        {
            var www = await ObservableWWW.GetWWW(url);

            return www;
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

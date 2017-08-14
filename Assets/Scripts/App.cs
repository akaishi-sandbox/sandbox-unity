using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class App : MonoBehaviour
{

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        DataStore.Instance.Register<Data.User>();
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        Debug.Log("destroy!!");
    }

    // Use this for initialization
    async void Start()
    {

        DataStore.Instance.Test = "sample";

        var name = DataStore.Instance.Get<Data.User>().Name;
        Debug.Log($"name => {name}");
        await aaa();

        var www = await HttpManager.Instance.WWW("https://redstone.biz");

        var ob = await HttpManager.Instance.ObWWW("https://redstone.biz");

        Debug.Log($"www: {www.text}");
        if (ob != null)
        {
            Debug.Log($"obwww: {ob.text}");
        }


    }

    /// <summary>
    /// Callback sent to all game objects when the player pauses.
    /// </summary>
    /// <param name="pauseStatus">The pause state of the application.</param>
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            DataStore.Instance.Save();
        }
    }

    async Task<string> aaa()
    {
        await Task.Delay(1000);


        return "end";
    }

    // Update is called once per frame
    void Update()
    {

    }
}

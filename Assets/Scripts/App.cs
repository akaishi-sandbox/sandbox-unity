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
        ServiceLocator.Instance.Register<DataStore>();
    }

    // Use this for initialization
    void Start()
    {

        aaa();

    }

    /// <summary>
    /// Callback sent to all game objects when the player pauses.
    /// </summary>
    /// <param name="pauseStatus">The pause state of the application.</param>
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            ServiceLocator.Instance.Get<DataStore>().Save();
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

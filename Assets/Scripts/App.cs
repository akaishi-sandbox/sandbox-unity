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
        ServiceLocator.Instance.Get<DataStore>().Ass();
        aaa();

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

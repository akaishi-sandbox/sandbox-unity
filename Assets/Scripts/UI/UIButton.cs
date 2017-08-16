using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;


[RequireComponent(typeof(UnityEngine.UI.Button))]
public class UIButton : BaseUI<UnityEngine.UI.Button>
{

    string savePath => $"{Application.persistentDataPath}/data.bin";

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // var path = Path.Combine(Application.persistentDataPath, "user.bin");


        Parts.Value.onClick.AsObservable()
        .Select(_ => 1)
            .Scan(0, (element, acc) => element + acc)
            .Subscribe(count =>
            {
                if (count == 2)
                {
                    SceneManager.LoadScene("sample2");
                }
            })
            .AddTo(gameObject);

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


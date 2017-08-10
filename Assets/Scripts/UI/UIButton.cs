using UnityEngine;
using UniRx;

namespace UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class UIButton : MonoBehaviour
    {
        System.Lazy<UnityEngine.UI.Button> buttonLazy => new System.Lazy<UnityEngine.UI.Button>(() => GetComponent<UnityEngine.UI.Button>());
        UnityEngine.UI.Button button => GetComponent<UnityEngine.UI.Button>();

        string savePath => $"{Application.persistentDataPath}/data.bin";

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            // var path = Path.Combine(Application.persistentDataPath, "user.bin");
            var builder = new FlatBuffers.FlatBufferBuilder(1);
            var data = Data.User.CreateUser(builder, 1, builder.CreateString("abcd"));
            Data.User.FinishUserBuffer(builder, data);

            System.IO.File.WriteAllBytes(savePath, builder.SizedByteArray());

            buttonLazy.Value.onClick.AsObservable()
            .Select(_ => 1)
                .Scan(0, (element, acc) => element + acc)
                .Subscribe(count => Debug.Log("countlazy:" + count))
                .AddTo(gameObject);

            button.onClick.AsObservable()
                .Select(_ => 1)
                .Scan(0, (element, acc) => element + acc)
                .Subscribe(count => Debug.Log("count:" + count))
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

}
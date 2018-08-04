using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.SerializableAttribute]
public class NewBehaviourScript1 : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Image image;

    public System.Action OnAction { get; set; }

    [UnityEngine.AddressableAssets.AssetReferenceTypeRestriction(typeof(Sprite))]
    [SerializeField] UnityEngine.AddressableAssets.AssetReference asset;

    List<Vector3> vec;
    // Use this for initialization
    void Start()
    {
        UnityEngine.AddressableAssets.Addressables.Instantiate<Sprite>(asset)
        .Completed += (tex) =>
        {
            image.sprite = tex.Result;
        };
        // var sprite = Resources.Load<Sprite>("Textures/apple");
        var sprite = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/apple.png", typeof(Sprite)) as Sprite;
        if (sprite == null)
        {
            Debug.LogError("sprite null");
        }
        vec = new List<Vector3>() {
            Vector3.zero,
            Vector3.one,
        };

        Save("todo", vec);

        var vec2 = Load<List<Vector3>>("todo");


        OnAction = () =>
        {
            Debug.Log("onaction call");
        };




    }

    // Update is called once per frame
    void Update()
    {

    }

    T Load<T>(string key)
    {
        if (false == PlayerPrefs.HasKey(key)) return default(T);
        var s = PlayerPrefs.GetString(key);
        if (null == s) return default(T);

        return JsonUtility.FromJson<T>(s);
        // #if UNITY_IOS
        //             System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        // #endif
        //         var b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //         var mem = new System.IO.MemoryStream(System.Convert.FromBase64String(s));
        //         return (T)b.Deserialize(mem);
    }
    void Save<T>(string key, T obj)
    {
        if (null == obj) return;
        //         var mem = new System.IO.MemoryStream();
        // #if UNITY_IOS
        //             System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        // #endif
        //         var b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //         b.Serialize(mem, obj);
        var s = JsonUtility.ToJson(obj);
        PlayerPrefs.SetString(key, s);
        // System.Convert.ToBase64String(mem.ToArray()));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.SerializableAttribute]
public class NewBehaviourScript1 : MonoBehaviour
{

    List<Vector3> vec;
    // Use this for initialization
    void Start()
    {
        vec = new List<Vector3>() {
            Vector3.zero,
            Vector3.one,
        };

        Save("todo", this);

        var obj = Load<NewBehaviourScript1>("todo");
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
#if UNITY_IOS
            System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
#endif
        var b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        var mem = new System.IO.MemoryStream(System.Convert.FromBase64String(s));
        return (T)b.Deserialize(mem);
    }
    void Save<T>(string key, T obj)
    {
        if (null == obj) return;
        var mem = new System.IO.MemoryStream();
#if UNITY_IOS
            System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
#endif
        var b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        b.Serialize(mem, obj);
        PlayerPrefs.SetString(key, System.Convert.ToBase64String(mem.ToArray()));
    }
}

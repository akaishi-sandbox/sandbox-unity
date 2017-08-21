using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

[RequireComponent(typeof(UnityEngine.UI.ScrollRect))]
public class UIScrollView : BaseUI<UnityEngine.UI.ScrollRect>
{

    // Use this for initialization
    void Start()
    {
        Parts.Value.onValueChanged.AsObservable()
        .Subscribe(abcdef =>
        {
            Debug.Log($"scroll?? {abcdef}");
        })
        .AddTo(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

[RequireComponent(typeof(UnityEngine.UI.Dropdown))]
public class UIDropdown : BaseUI<UnityEngine.UI.Dropdown>
{

    // Use this for initialization
    void Start()
    {
        Parts.Value.onValueChanged.AsObservable()
        .Subscribe(drop =>
        {
            Debug.Log($"drop change:{drop}!!");
        })
        .AddTo(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

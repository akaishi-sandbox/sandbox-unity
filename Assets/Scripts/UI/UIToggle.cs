using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;


[RequireComponent(typeof(UnityEngine.UI.Toggle))]
public class UIToggle : BaseUI<UnityEngine.UI.Toggle>
{

    // Use this for initialization
    void Start()
    {
        ui.Value.onValueChanged.AsObservable()
        .Subscribe(x =>
        {
            Debug.Log($"toggle:{x}");
            if (x)
            {

            }
        })
        .AddTo(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

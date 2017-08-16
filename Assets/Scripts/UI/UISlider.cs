using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;


[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class UISlider : BaseUI<UnityEngine.UI.Slider>
{

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Parts.Value.onValueChanged.AsObservable()
        .Subscribe(v =>
        {
            Debug.Log($"slider value:{v}");
        })
        .AddTo(gameObject);
    }
}
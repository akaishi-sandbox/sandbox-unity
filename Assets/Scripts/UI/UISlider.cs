using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using System.Linq;


[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class UISlider : BaseUI<UnityEngine.UI.Slider>
{

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        ui.Value.onValueChanged.AsObservable()
        .Buffer(3)
        // .Where(v => System.Math.Abs(v.First() - v.Last()) > 0.01)
        .Select(v => v.Last())
        .Subscribe(v =>
        {
            Debug.Log($"slider value:{v}");
            if (v > 0.8)
            {
                SceneManager.LoadScene("sample3");
                Destroy(gameObject);
            }
        })
        .AddTo(gameObject);
    }
}
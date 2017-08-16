using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;


public abstract class BaseUI<T> : MonoBehaviour where T : UnityEngine.UI.Selectable
{
    protected System.Lazy<T> Parts => new System.Lazy<T>(() => GetComponent<T>());
}
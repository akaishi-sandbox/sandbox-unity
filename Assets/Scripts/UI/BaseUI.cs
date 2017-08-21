using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;


public abstract class BaseUI<T> : MonoBehaviour where T : UnityEngine.EventSystems.UIBehaviour
{
    protected System.Lazy<T> Parts => new System.Lazy<T>(() => GetComponent<T>());
}
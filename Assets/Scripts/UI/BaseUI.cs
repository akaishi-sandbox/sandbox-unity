using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;


public abstract class BaseUI<T> : MonoBehaviour where T : UnityEngine.EventSystems.UIBehaviour
{
    protected System.Lazy<T> ui => new System.Lazy<T>(() => GetComponent<T>());
}
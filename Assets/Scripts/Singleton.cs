using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> where T : class
{

    static readonly Lazy<T> instance = new Lazy<T>(() => Activator.CreateInstance(typeof(T)) as T);

    public static T Instance => instance.Value;

}

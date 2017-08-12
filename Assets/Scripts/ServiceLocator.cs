using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ServiceLocator : Singleton<ServiceLocator>
{

    readonly Dictionary<Type, Lazy<object>> registeredServices = new Dictionary<Type, Lazy<object>>();

    public void Register<T>() where T : new()
    {
        registeredServices[typeof(T)] = new Lazy<object>(() => Activator.CreateInstance(typeof(T)));
    }

    public T Get<T>() where T : class
    {
        Lazy<object> service;
        if (registeredServices.TryGetValue(typeof(T), out service))
        {
            return service.Value as T;
        }

        return null;
    }
}

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observer : MonoBehaviour
{
    static Dictionary<string, List<Action<object[]>>> Listeners =
        new Dictionary<string, List<Action<object[]>>>();
    public static void AddObserver(string name, Action<object[]> callback)
    {
        if (!Listeners.ContainsKey(name))
        {
            Listeners.Add(name, new List<Action<object[]>>());
        }
        Listeners[name].Add(callback);
    }
    public static void RemoveObserver(string name, Action<object[]> callback)
    {
        if (!Listeners.ContainsKey(name)) return;
        Listeners[name].Remove(callback);
    }
    public static void Notify(string name, params object[] datas)
    {
        if (!Listeners.ContainsKey(name))
        {
            return;
        }
        foreach (var item in Listeners[name])
        {
            try
            {
                 item?.Invoke(datas);
            }
            catch (Exception e)
            {   
                Debug.LogError("Error on invoke: " + e);
            }
        }
    }
}

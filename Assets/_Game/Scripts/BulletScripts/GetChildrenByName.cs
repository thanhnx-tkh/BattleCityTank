using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildrenByName : Singleton<GetChildrenByName>
{
    public T GetComponentInChildrenByName<T>(string childName) where T : Component
    {
        T[] components = GetComponentsInChildren<T>();

        foreach (T component in components)
        {
            if (component.gameObject.name == childName)
            {
                return component;
            }
        }

        return null;
    }
}

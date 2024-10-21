using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePlay : Singleton<UIGamePlay>
{
    public List<GameObject> gameObjects;
    private void Start()
    {
        foreach (Transform gameObject in transform)
        {
            gameObjects.Add(gameObject.gameObject);
        }
    }
    public void UiEnable(string nameUi)
    {
        GameObject uiLose = gameObjects.Find(name  => name.gameObject.name == nameUi);
        uiLose.SetActive(true);
    }
}

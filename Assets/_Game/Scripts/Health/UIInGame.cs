using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : UICanvas
{
    public List<GameObject> gameObjects;
    private void Start()
    {
        foreach (Transform gameObject in transform)
        {
            gameObjects.Add(gameObject.gameObject);
        }
        SpawnPlayer._ins.onSpawn?.AddListener(UiEnable);
        BaseHealth.Instance.onLose?.AddListener(UiEnable);
    }
    public void UiEnable(string nameUi)
    {
        GameObject uiObject = gameObjects.Find(ui  => ui.name == nameUi);
        uiObject.SetActive(true);
        Time.timeScale  = 1.0f;
    }
}

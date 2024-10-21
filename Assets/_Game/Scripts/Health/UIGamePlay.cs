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
        GameObject uiObject = gameObjects.Find(ui  => ui.name == nameUi);
        uiObject.SetActive(true);
        Time.timeScale  = 1.0f;
    }
    public void PauseUI()
    {
        Time.timeScale = 0f;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
    }
}

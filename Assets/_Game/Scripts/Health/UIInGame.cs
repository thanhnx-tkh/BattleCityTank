using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : UICanvas
{
    [SerializeField] private PlayerHealth playerHealth;
    public List<GameObject> gameObjects;
    [SerializeField] private float timeScale;
    private void Start()
    {
        foreach (Transform gameObject in transform)
        {
            gameObjects.Add(gameObject.gameObject);
        }
        playerHealth = GameObject.FindGameObjectWithTag(Const.playerTag).GetComponent<PlayerHealth>();
        playerHealth.onSpawn?.AddListener(UiEnable);
    }
    public void UiEnable(string nameUi)
    {
        GameObject uiObject = gameObjects.Find(ui  => ui.name == nameUi);
        uiObject.SetActive(true);
        Time.timeScale  = 1.0f;
    }
}

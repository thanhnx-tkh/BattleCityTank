using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : UICanvas
{
    [SerializeField] private PlayerHealth playerHealth;
    public List<GameObject> gameObjects;
    [SerializeField] private List<Button> buttons;
    [SerializeField] private float timeScale;
    private void Awake()
    {
        foreach (Transform gameObject in transform)
        {
            gameObjects.Add(gameObject.gameObject);
        }
    }
    private void Start()
    {
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

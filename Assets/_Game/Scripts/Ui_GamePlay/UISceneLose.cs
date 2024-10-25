using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISceneLose : UICanvas
{
    [SerializeField] private Button mainButton;
    [SerializeField] private Button mainRetryGame;
    [SerializeField] private string scene;
    private void Start()
    {
        mainButton.onClick?.AddListener(BackMainMenu);
        mainRetryGame.onClick?.AddListener(RetryGame);
    }
    public void BackMainMenu()
    {
        SceneTransitionManager.Instance.LoadSceneWithLoadingScreen(scene);
    }
    public void RetryGame(){
        SceneTransitionManager.Instance.LoadSceneWithLoadingScreen("Lv" + (LevelManager.Ins.currentLevel + 1));

    }
}

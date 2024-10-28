using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScneneWin : UICanvas
{
    [SerializeField] private Button mainButton;
    [SerializeField] private Button mainNextLevel;
    [SerializeField] private string scene;
    private void Start()
    {
        mainButton.onClick?.AddListener(BackMainMenu);
        mainNextLevel.onClick?.AddListener(NextLevel);
    }
    public void BackMainMenu()
    {
        SceneTransitionManager.Instance.LoadSceneWithLoadingScreen(scene);
    }
    public void NextLevel()
    {
        if (LevelManager.Ins.currentLevel < 3)
        {
            SceneTransitionManager.Instance.LoadSceneWithLoadingScreen("Lv" + (LevelManager.Ins.currentLevel + 1));
        }
        else
        {
            LevelManager.Ins.currentLevel = 0;
        }
    }
}

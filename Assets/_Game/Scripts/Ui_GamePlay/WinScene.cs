using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScene : UICanvas
{
    [SerializeField] private Button mainButton;
    [SerializeField] private string scene;
    private void Start()
    {
        mainButton.onClick?.AddListener(BackMainMenu);
    }
    public void BackMainMenu()
    {
        SceneManager.LoadSceneAsync(scene);
    }
}

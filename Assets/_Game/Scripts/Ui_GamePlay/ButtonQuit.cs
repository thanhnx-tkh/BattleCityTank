using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    [SerializeField] private Button buttonQuit;
    public string nameScene;
    void Start()
    {
        buttonQuit.onClick?.AddListener(QuitMap);
    }
    public void QuitMap()
    {
        SceneTransitionManager.Instance.LoadSceneWithLoadingScreen(nameScene);
        //SceneManager.LoadSceneAsync(nameScene);
    }
}

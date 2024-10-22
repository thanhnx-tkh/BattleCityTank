using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button pauseButton;

    private void Start()
    {
        pauseButton.onClick?.AddListener(Click);
    }
    private void Click()
    {
        Time.timeScale = 0f;
    }
}

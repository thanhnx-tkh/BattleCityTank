using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Start()
    {
        continueButton.onClick?.AddListener(Click);
    }
    private void Click()
    {
        Time.timeScale = 1.0f;
    }
}

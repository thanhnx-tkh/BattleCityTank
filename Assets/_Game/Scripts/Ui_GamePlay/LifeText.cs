using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeText;
    void Start()
    {
        SpawnPlayer._ins.onLifeChange?.AddListener(ChangeLifeText);
    }
    public void ChangeLifeText(int lifeCount)
    {
        lifeText.text = lifeCount.ToString();
    }
}

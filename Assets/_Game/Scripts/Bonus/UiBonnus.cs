using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiBonnus : MonoBehaviour
{
    [SerializeField] private GameObject frozenObj;
    [SerializeField] private GameObject shieldObj;
    [SerializeField] private Button frozenButton;
    [SerializeField] private Button shieldButton;
    [SerializeField] private TextMeshProUGUI levelText;
    public static UiBonnus Instance;
    [field: SerializeField] public bool isFrozen { get; set; }
    [field: SerializeField] public bool isShield { get; set; }
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }
    void Start()
    {
        frozenObj.SetActive(LevelManager.Ins.isFrozen);
        shieldObj.SetActive(LevelManager.Ins.isResilient);
        frozenButton.onClick?.AddListener(UseFrozenBonus);
        shieldButton.onClick?.AddListener(UseShieldBonus);
        if(LevelManager.Ins.currentLevel >=0 && LevelManager.Ins.currentLevel<10)
            levelText.text = "Level: " + (LevelManager.Ins.currentLevel + 1).ToString();
    }

    public void UseFrozenBonus()
    {
        Observer.Notify("Frozen");
    }
    public void UseShieldBonus()
    {
        Observer.Notify("Shield");
    }
}

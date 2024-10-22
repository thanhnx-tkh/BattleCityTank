using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBonus : MonoBehaviour
{
    [SerializeField] private Button shieldButton;

    [field: SerializeField] public bool isShield {  get; set; }

    private void Start()
    {
        shieldButton.onClick?.AddListener(UseShieldBonus);
    }
    public void UseShieldBonus()
    {
        isShield = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : Singleton<ShieldBonus>
{
    [field: SerializeField] public bool isShield {  get; set; }

    public void UseShieldBonus()
    {
        isShield = true;
    }
}

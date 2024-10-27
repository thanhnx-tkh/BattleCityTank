using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePuschaseButton : MonoBehaviour
{
    [field: SerializeField] public int value { get;  set; }

    public virtual void BuyCoin()
    {
        DataManager.Ins.UpdateMoney(value);
    }
}

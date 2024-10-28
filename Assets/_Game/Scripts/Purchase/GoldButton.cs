using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using UnityEngine.UIElements;

public class GoldButton : BasePuschaseButton
{
    [field: SerializeField] public bool isBuy { get; set; }
    public void OnPurchaseComplete(Product product)
    {
        isBuy = true;
        Observer.Notify("UpdateGold");
    }
}

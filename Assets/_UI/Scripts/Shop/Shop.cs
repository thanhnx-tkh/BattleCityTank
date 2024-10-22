using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : UICanvas
{
    public Text textGold;
    private void Start()
    {
        Observer.AddObserver("UpdateUI", UpdateTextGold);
    }
    private void UpdateTextGold(object[] datas)
    {
        textGold.text = DataManager.Ins.GetCurrentMoney().ToString();
    }
    public void OnDestroy()
    {
        Observer.RemoveObserver("UpdateUI", UpdateTextGold);
    }
}

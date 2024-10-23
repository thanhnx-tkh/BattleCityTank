using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : UICanvas
{
    public Text textGold;
    public Button backMainMenu;
    private void Start()
    {
        backMainMenu.onClick.AddListener(BackMainMenu);
        Observer.AddObserver("UpdateUI", UpdateTextGold);
    }
    private void OnEnable() {
        Observer.Notify("UpdateUI");
        textGold.text = DataManager.Ins.GetCurrentMoney().ToString();
    }
    private void UpdateTextGold(object[] datas)
    {
        textGold.text = DataManager.Ins.GetCurrentMoney().ToString();
    }
    public void OnDestroy()
    {
        Observer.RemoveObserver("UpdateUI", UpdateTextGold);
    }
    public void BackMainMenu(){
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<MianMenu>();
        UIManager.Ins.OpenUI<BarMenu>();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : UICanvas
{
    public Text textGold;
    public Button backMainMenu;
    public Button plusButton;
    private void Start()
    {
        backMainMenu.onClick.AddListener(BackMainMenu);
        plusButton.onClick.AddListener(PlusButton);
        Observer.AddObserver("UpdateUI", UpdateTextGold);
    }
    private void OnEnable() {
        transform.SetAsLastSibling();
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
        Close(0);
        UIManager.Ins.OpenUI<MianMenu>();
        UIManager.Ins.OpenUI<BarMenu>();
    }
    public void PlusButton()
    {
        Close(0);
        Observer.Notify("ChangeAnimButtonShop");
    }
}

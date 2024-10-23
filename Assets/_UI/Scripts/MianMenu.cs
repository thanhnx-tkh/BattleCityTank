using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MianMenu : UICanvas
{
    public Button upgradeButton;
    public Button shopButton;
    public Button playButton;
    public Button giftButton;

    public Text textGold;
    public Text textScore;
    private void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeButton);
        playButton.onClick.AddListener(PlayButton);
        giftButton.onClick.AddListener(GiftButton);
        shopButton.onClick.AddListener(ShopButton);

        Observer.AddObserver("UpdateUI", UpdateTextGold);
        Observer.AddObserver("UpdateUI", UpdateTextScore);

    }
    private void OnEnable()
    {
        Observer.Notify("UpdateUI");
        transform.SetAsFirstSibling();
    }
    private void UpdateTextGold(object[] datas)
    {
        textGold.text = DataManager.Ins.GetCurrentMoney().ToString();
    }
    private void UpdateTextScore(object[] datas)
    {
        textScore.text = "Score: " + DataManager.Ins.GetCurrentScore().ToString();
    }
    public void UpgradeButton()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Upgrade>();
    }
    public void PlayButton()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<PlayGame>();
    }
    public void ShopButton()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Shop>();
    }

    public void GiftButton()
    {

    }

    public void OnDestroy()
    {
        Observer.RemoveObserver("UpdateUI", UpdateTextGold);
        Observer.RemoveObserver("UpdateUI", UpdateTextScore);
    }
}

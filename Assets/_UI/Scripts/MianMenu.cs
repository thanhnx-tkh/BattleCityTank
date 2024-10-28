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
    public Button plusButton;

    public Text textGold;
    public Text textScore;
    
    private void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeButton);
        playButton.onClick.AddListener(PlayButton);
        giftButton.onClick.AddListener(GiftButton);
        shopButton.onClick.AddListener(ShopButton);
        plusButton.onClick.AddListener(PlusButton);

        Observer.AddObserver("UpdateUI", UpdateTextGold);
        Observer.AddObserver("UpdateUI", UpdateTextScore);
        textGold.text = DataManager.Ins.GetCurrentMoney().ToString();
        LevelManager.Ins.isFrozen = false;
        LevelManager.Ins.isResilient = false;
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
        Close(0);
        UIManager.Ins.OpenUI<Upgrade>();
    }
    public void PlayButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<PlayGame>();
    }
    public void ShopButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<Shop>();
    }

    public void GiftButton()
    {
        Close(0);
        Observer.Notify("ChangeAnimButtonShop");
    }
    public void PlusButton()
    {
        Close(0);
        Observer.Notify("ChangeAnimButtonShop");
    }
    public void OnDestroy()
    {
        Observer.RemoveObserver("UpdateUI", UpdateTextGold);
        Observer.RemoveObserver("UpdateUI", UpdateTextScore);
    }
}

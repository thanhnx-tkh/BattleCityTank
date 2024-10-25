using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : UICanvas
{
    public Button backHome;
    public Button buttonFrozen;
    public GameObject Forzen;
    public Button buttonResilient;
    public GameObject Resilient;
    public Button buttonPlay;
    public Text textCoin;
    private void Start()
    {
        Observer.AddObserver("UpdateUI", UpdateTextGold);
        buttonFrozen.onClick.AddListener(ButtonFrozen);
        buttonResilient.onClick.AddListener(ButtonResilient);
        buttonPlay.onClick.AddListener(ButtonPlay);
        backHome.onClick.AddListener(BackHome);
    }
    private void OnEnable()
    {
        textCoin.text = DataManager.Ins.GetCurrentMoney().ToString();
        if (LevelManager.Ins.isFrozen)
        {
            Forzen.SetActive(false);
        }
        else
        {
            Forzen.SetActive(true);
        }
        if (LevelManager.Ins.isResilient)
        {
            Resilient.SetActive(false);
        }
        else
        {
            Resilient.SetActive(true);
        }
    }
    private void UpdateTextGold(object[] datas)
    {
        textCoin.text = DataManager.Ins.GetCurrentMoney().ToString();
    }
    public void ButtonFrozen()
    {
        if ((DataManager.Ins.GetCurrentMoney() - 500) < 0) return;
        Forzen.SetActive(false);
        if (LevelManager.Ins.isFrozen) return;
        LevelManager.Ins.isFrozen = true;
        DataManager.Ins.UpdateMoneyBuyTank(500);
        Observer.Notify("UpdateUI");
    }
    public void ButtonResilient()
    {
        if ((DataManager.Ins.GetCurrentMoney() - 300) < 0) return;
        Resilient.SetActive(false);
        if (LevelManager.Ins.isResilient) return;
        LevelManager.Ins.isResilient = true;
        DataManager.Ins.UpdateMoneyBuyTank(300);
        Observer.Notify("UpdateUI");
    }
    public void ButtonPlay()
    {
        //SceneManager.LoadScene("Lv" + (LevelManager.Ins.currentLevel + 1));
        SceneTransitionManager.Instance.LoadSceneWithLoadingScreen("Lv" + (LevelManager.Ins.currentLevel + 1));

    }

    private void OnDestroy()
    {
        Observer.RemoveObserver("UpdateUI", UpdateTextGold);
    }
    public void BackHome(){
        Close(0);
        UIManager.Ins.OpenUI<MianMenu>();
        UIManager.Ins.OpenUI<BarMenu>();
    }
}

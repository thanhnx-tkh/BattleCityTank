using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarMenu : UICanvas
{
    public Button mapButton;
    public Button shopButton;
    public Button eventsButton;
    public Button homeButton;
    [SerializeField] Animator anim;
    private string animName = "Home";


    private void Start()
    {
        ChangeAnim("Home");
        Debug.Log(animName);
        mapButton.onClick.AddListener(MapButton);
        shopButton.onClick.AddListener(ShopButton);
        eventsButton.onClick.AddListener(EventsButton);
        homeButton.onClick.AddListener(HomeButton);

        Observer.AddObserver("ChangeAnimButtonShop", ShopButton_2);
    }
    public void ChangeAnim(string animName)
    {
        if (this.animName != animName)
        {
            anim.ResetTrigger(this.animName);
            this.animName = animName;
            anim.SetTrigger(this.animName);
        }
    }
    private void OnEnable()
    {
        ChangeAnim("Idle");
        ChangeAnim("Home");
    }
    public void MapButton()
    {
        ChangeAnim("Idle");

        CloseUI();

        UIManager.Ins.OpenUI<BarMenu>();
        UIManager.Ins.OpenUI<Map>();
        ChangeAnim("Map");
    }
    public void ShopButton()
    {
        ChangeAnim("Idle");

        CloseUI();

        UIManager.Ins.OpenUI<UIShop>();
        UIManager.Ins.OpenUI<BarMenu>();
        ChangeAnim("Shop");
    }
    public void ShopButton_2(object[] data)
    {
        ChangeAnim("Idle");

        CloseUI();

        UIManager.Ins.OpenUI<UIShop>();
        UIManager.Ins.OpenUI<BarMenu>();
        Debug.Log("Chay");
        ChangeAnim("Shop");
    }
    public void EventsButton()
    {
        ChangeAnim("Idle");

        CloseUI();

        UIManager.Ins.OpenUI<Event>();
        UIManager.Ins.OpenUI<BarMenu>();

        ChangeAnim("Event");
    }
    public void HomeButton()
    {
        ChangeAnim("Idle");

        CloseUI();

        UIManager.Ins.OpenUI<BarMenu>();
        UIManager.Ins.OpenUI<MianMenu>();

        ChangeAnim("Home");
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver("ChangeAnimButtonShop", ShopButton_2);
    }

    private void CloseUI()
    {
        UIManager.Ins.CloseUI<MianMenu>();
        UIManager.Ins.CloseUI<Map>();
        UIManager.Ins.CloseUI<UIShop>();
        UIManager.Ins.CloseUI<Event>();
    }
}

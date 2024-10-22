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

    private void Start()
    {
        mapButton.onClick.AddListener(MapButton);
        shopButton.onClick.AddListener(ShopButton);
        eventsButton.onClick.AddListener(EventsButton);
        homeButton.onClick.AddListener(HomeButton);
    }
    public void MapButton()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Map>();
        UIManager.Ins.OpenUI<BarMenu>();
    }
    public void ShopButton()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Shop>();
        UIManager.Ins.OpenUI<BarMenu>();
    }
    public void EventsButton()
    {
        //UIManager.Ins.CloseAll();
        //UIManager.Ins.OpenUI<Event>();
        SceneManager.LoadScene("MapLv1");
    }
    public void HomeButton()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<MianMenu>();
        UIManager.Ins.OpenUI<BarMenu>();
    }
}

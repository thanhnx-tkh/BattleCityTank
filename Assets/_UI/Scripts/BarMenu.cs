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
    public string animName = "Home";


    private void Start()
    {
        ChangeAnim("Home");
        Debug.Log(animName);
        mapButton.onClick.AddListener(MapButton);
        shopButton.onClick.AddListener(ShopButton);
        eventsButton.onClick.AddListener(EventsButton);
        homeButton.onClick.AddListener(HomeButton);
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
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Map>();
        UIManager.Ins.OpenUI<BarMenu>();
        ChangeAnim("Map");
    }
    public void ShopButton()
    {
        ChangeAnim("Idle");
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Shop>();
        UIManager.Ins.OpenUI<BarMenu>();
        ChangeAnim("Shop");
    }
    public void EventsButton()
    {
        ChangeAnim("Idle");

        //UIManager.Ins.CloseAll();
        //UIManager.Ins.OpenUI<Event>();
        ChangeAnim("Event");
    }
    public void HomeButton()
    {
        
        ChangeAnim("Idle");
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<MianMenu>();
        UIManager.Ins.OpenUI<BarMenu>();

        ChangeAnim("Home");
    }
}

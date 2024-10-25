using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopDetail : UICanvas
{
    public int Id;
    public ShopData shopDatas;
    public Model3D model3D;
    [SerializeField] Button btnExit;
    [SerializeField] Button btnBuy;
    [SerializeField] GameObject parentModel3D;
    [SerializeField] Text nameTank;
    [Header("Dame")]
    [SerializeField] Slider sliderDame;
    [SerializeField] Text textDame;
    [Header("HP")]
    [SerializeField] Slider sliderHp;
    [SerializeField] Text textHp;
    [Header("Speed")]
    [SerializeField] Slider sliderSpeed;
    [SerializeField] Text textSpeed;
    [Header("Coin")]
    [SerializeField] Text textCoin;

    private GameObject currentTank;
    private float speedRotate = 20;

    private void Start()
    {
        SetData();
        InstantiateModel3D();
        btnExit.onClick.AddListener(ButtonExitShop);
        btnBuy.onClick.AddListener(ButtonBuyShop);
    }
    private void Update()
    {
        currentTank.transform.Rotate(Vector3.up * speedRotate * Time.deltaTime);
    }

    private void SetData()
    {
        var tank = shopDatas.itemDatas[Id];
        nameTank.text = tank.name;
        //max dame 500
        sliderDame.value = tank.damage;
        textDame.text = $"{tank.damage}";
        //max hp 800
        sliderHp.value = tank.maxHealth;
        textHp.text = $"{tank.maxHealth}";  
        //max speed 200
        sliderSpeed.value = tank.speed; ;
        textSpeed.text = $"{tank.speed}";
        textCoin.text = tank.price.ToString();
    }

    private void InstantiateModel3D()
    {
        GameObject modelTank = Instantiate(model3D.GetModel3D(Id), parentModel3D.transform);
        modelTank.transform.localPosition = Vector3.zero;
        modelTank.transform.localRotation = Quaternion.identity;
        modelTank.transform.localScale = model3D.GetScaleModel3D(Id);
        currentTank = modelTank;
    }

    private void ButtonExitShop()
    {
        Close(0);
        UIManager.Ins.OpenUI<Shop>();
    }  

    public void ButtonBuyShop()
    {
        int price =(int)shopDatas.itemDatas[Id].price;
        if (DataManager.Ins.GetCurrentMoney() - price >= 0)
        {
            DataManager.Ins.UpdateMoneyBuyTank(price);
            Close(0);
            DataManager.Ins.PurchaseTank(Id);
            UIManager.Ins.OpenUI<Shop>();
            Observer.Notify("UpdateUI");
        }
        if ((DataManager.Ins.GetCurrentMoney() - price) < 0)
        {
            Close(0);
            Observer.Notify("ChangeAnimButtonShop");
        }
    }
}

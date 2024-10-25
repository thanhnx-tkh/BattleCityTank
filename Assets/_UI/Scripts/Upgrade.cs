using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : UICanvas
{
    public ShopData shopDatas;
    public Model3D model3D;
    [SerializeField] GameObject parentModel3D;
    [SerializeField] Text nameTank;
    [SerializeField] Text coinTextPlayer;
    [SerializeField] Text coinTextUpdate;
    [SerializeField] Button btnPlayNow;
    [SerializeField] Button btnUpdateTank;
    [SerializeField] Button btnBack;
    [SerializeField] Button btnPurchase;
    [SerializeField] Button changeTankLeft;
    [SerializeField] Button changeTankRight;
    [Header("Dame")]
    [SerializeField] Slider sliderDame;
    [SerializeField] Text textDame;
    [Header("HP")]
    [SerializeField] Slider sliderHp;
    [SerializeField] Text textHp;
    [Header("Speed")]
    [SerializeField] Slider sliderSpeed;
    [SerializeField] Text textSpeed;
    [Header("Level")]
    [SerializeField] Slider sliderLevel;
    [SerializeField] Text textLevel;
    private GameObject currentTank;
    private float speedRotate = 20;
    private int currentId = 0;
    private List<int> listPurchasedTankId;
    // Start is called before the first frame update
    void Start()
    {
        listPurchasedTankId = DataManager.Ins.GetListPurchasedTankById();
 
        SetData(listPurchasedTankId[0]);
        InstantiateModel3D(listPurchasedTankId[0]);

        btnPlayNow.onClick.AddListener(PlayNow);
        btnUpdateTank.onClick.AddListener(() => UpdateTank(listPurchasedTankId[currentId]));
        btnBack.onClick.AddListener(Back);
        btnPurchase.onClick.AddListener(Purchase);
        changeTankLeft.onClick.AddListener(OnClickChangeTankLeft);
        changeTankRight.onClick.AddListener(OnClickChangeTankRight);
    }

    // Update is called once per frame
    void Update()
    {
        currentTank.transform.Rotate(Vector3.up * speedRotate * Time.deltaTime);
    }

    private void InstantiateModel3D(int currentId)
    {
        GameObject modelTank = Instantiate(model3D.GetModel3D(listPurchasedTankId[currentId]), parentModel3D.transform);
        modelTank.transform.localPosition = Vector3.zero;
        modelTank.transform.localRotation = Quaternion.identity;
        modelTank.transform.localScale = model3D.GetScaleModel3D(listPurchasedTankId[currentId]);
        currentTank = modelTank;

    }

    private void OnClickChangeTankLeft()
    {
        if (currentId > 0)
        {
            //Destroy currentTank
            Destroy(currentTank);
            //Show previous tank
            currentId -= 1;
            SetData(listPurchasedTankId[currentId]);
            InstantiateModel3D(currentId);
        }
    }

    private void OnClickChangeTankRight()
    {
        if (currentId < listPurchasedTankId.Count - 1)
        {
            //Destroy currentTank
            Destroy(currentTank);
            //Show next tank
            currentId += 1;
            SetData(listPurchasedTankId[currentId]);
            InstantiateModel3D(currentId);
        }
    }

    private void SetData(int id)
    {
        var tank = shopDatas.itemDatas[id];
        int lvById = DataManager.Ins.GetTankLevelbyId(id);
        nameTank.text = tank.name;
        //text coin top
        coinTextPlayer.text = DataManager.Ins.GetCurrentMoney().ToString();
        //text coin update
        coinTextUpdate.text =  (lvById * 500).ToString();
        //max dame 500
        sliderDame.value = tank.damage + (lvById * 10);
        textDame.text = $"{tank.damage + (lvById * 10)}";
        //max hp 800
        sliderHp.value = tank.maxHealth + (lvById * 10);
        textHp.text = $"{tank.maxHealth + (lvById * 10)}";
        //max speed 200
        sliderSpeed.value = tank.speed + (lvById * 10); ;
        textSpeed.text = $"{tank.speed + (lvById * 10)}";
        //max level = 10
        sliderLevel.value = DataManager.Ins.GetTankLevelbyId(listPurchasedTankId[currentId]);
        textLevel.text = $"Lv.{DataManager.Ins.GetTankLevelbyId(listPurchasedTankId[currentId])}";
    }

    public void UpdateTank(int id)
    {
        int level = DataManager.Ins.GetTankLevelbyId(id);
        int coinUpdate = DataManager.Ins.GetTankLevelbyId(id) * 500;
        int moneyLeft = DataManager.Ins.GetCurrentMoney();
        if (level < 10 && moneyLeft >= coinUpdate)
        {
            DataManager.Ins.UpgradeTank(id);
            DataManager.Ins.UpdateMoneyBuyTank(coinUpdate);
            SetData(id);
        }
        if (moneyLeft < coinUpdate)
        {
            Close(0);
            Observer.Notify("ChangeAnimButtonShop");
        }
    }

    public void Back()
    {
        Close(0);
        UIManager.Ins.OpenUI<MianMenu>();
        UIManager.Ins.OpenUI<BarMenu>();
    }
    public void PlayNow()
    {
        Close(0);
        LevelManager.Ins.currentTankId = listPurchasedTankId[currentId];
        LevelManager.Ins.currentLevel = DataManager.Ins.GetUnlockLevel()[DataManager.Ins.GetUnlockLevel().Count-1];
        UIManager.Ins.OpenUI<PlayGame>();
    }

    public void Purchase()
    {
        Close(0);
        Observer.Notify("ChangeAnimButtonShop");
    }

}

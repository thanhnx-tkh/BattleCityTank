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

    private int currentId = 1;
    private int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        SetData(currentId);
        InstantiateModel3D(currentId);
        btnPlayNow.onClick.AddListener(PlayNow);
        btnUpdateTank.onClick.AddListener(() => UpdateTank(currentId));
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
        GameObject modelTank = Instantiate(model3D.GetModel3D(currentId), parentModel3D.transform);
        modelTank.transform.localPosition = Vector3.zero;
        modelTank.transform.localRotation = Quaternion.identity;
        modelTank.transform.localScale = model3D.GetScaleModel3D(currentId);
        currentTank = modelTank;

    }

    private void OnClickChangeTankLeft()
    {
        if (currentId > 1)
        {
            //Destroy currentTank
            Destroy(currentTank);
            //Show previous tank
            currentId -= 1;
            SetData(currentId);
            InstantiateModel3D(currentId);
        }
    }

    private void OnClickChangeTankRight()
    {
        if (currentId < model3D.itemDatas.Count)
        {
            //Destroy currentTank
            Destroy(currentTank);
            //Show next tank
            currentId += 1;
            SetData(currentId);
            InstantiateModel3D(currentId);
        }
    }

    private void SetData(int id)
    {
        currentId = id;
        var tank = shopDatas.itemDatas[id+-1];

        nameTank.text = tank.name;
        //text coin top
        coinTextPlayer.text = "100";
        //text coin update
        coinTextUpdate.text = "2";
        //max dame 500
        sliderDame.value = tank.damage;
        textDame.text = $"{tank.damage}";
        //max hp 800
        sliderHp.value = tank.maxHealth;
        textHp.text = $"{tank.maxHealth}";
        //max speed 200
        sliderSpeed.value = tank.speed; ;
        textSpeed.text = $"{tank.speed}";
        //max level = 10
        sliderLevel.value = currentLevel;
        textLevel.text = $"Lv.{currentLevel}";
    }

    public void UpdateTank(int id)
    {

        var tank = shopDatas.itemDatas[id];
        //max dame 500
        if (sliderDame.value <= sliderDame.maxValue)
        {
            sliderDame.value = tank.damage + 100;
            textDame.text = $"{tank.damage + 100}";
        }
        else
        {
            sliderDame.value = sliderDame.maxValue;
        }
        if (sliderHp.value <= sliderHp.maxValue)
        {
            //max hp 800
            sliderHp.value = tank.maxHealth + 100;
            textHp.text = $"{tank.maxHealth + 100}";
        }
        else
        {
            sliderHp.value = sliderHp.maxValue;
        }
        if (sliderSpeed.value <= sliderSpeed.maxValue)
        {
            //max speed 200
            sliderSpeed.value = tank.speed + 100; ;
            textSpeed.text = $"{tank.speed + 100}";
        }
        else
        {
            sliderSpeed.value = sliderSpeed.maxValue;
        }
        //max level = 10
        if (sliderLevel.value <= 10)
        {
            sliderLevel.value = currentLevel + 1;
            textLevel.text = $"Lv.{currentLevel + 1}";
        }
    }

    public void Back()
    {
        Debug.Log("Back");
    }
    public void PlayNow()
    {
        Debug.Log("Play");
    }

    public void Purchase()
    {
        Debug.Log("Purchase");
    }

    private void UpdateCoin(int playerCoin, int updateCoin)
    {
        playerCoin -= updateCoin;
        coinTextPlayer.text = playerCoin.ToString();
        coinTextUpdate.text = updateCoin.ToString();
    }
}

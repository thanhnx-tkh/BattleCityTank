using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObjects/ShopData", order = 1)]
public class ShopData : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = true)]
    public List<ShopItemData> itemDatas;
    public List<ShopItemData> GetTankNotPurchased()
    {
        List<ShopItemData> listTankNotPurchased = new List<ShopItemData>();

        for (int i = 0; i < itemDatas.Count; i++)
        {
            if (!DataManager.Ins.GetListPurchasedTankById().Contains(itemDatas[i].id))
            {
                listTankNotPurchased.Add(itemDatas[i]);
            }
        }
        return listTankNotPurchased;
    }
    public List<ShopItemData> GetTankPurchased()
    {
        List<ShopItemData> listTankNotPurchased = new List<ShopItemData>();

        for (int i = 0; i < itemDatas.Count; i++)
        {
            if (DataManager.Ins.GetListPurchasedTankById().Contains(itemDatas[i].id))
            {
                listTankNotPurchased.Add(itemDatas[i]);
            }
        }
        return listTankNotPurchased;
    }

}

[System.Serializable]
public class ShopItemData
{
    [HorizontalGroup("Split", 75)]
    [HideLabel]
    [PreviewField(75)]
    [VerticalGroup("Split/Left")]
    public Sprite sprite;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public int id;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public string name;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public float price;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public GameObject tankObj;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    [Range(0, 500)]
    [GUIColor(1f, 0.5f, 0.5f)]
    public float damage;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    [Range(0, 1000)]
    [GUIColor(0.5f, 1f, 0.5f)]
    public float maxHealth;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    [Range(0, 300)]
    [GUIColor(0.5f, 0.5f, 1f)]
    public float speed;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemShopUI : MonoBehaviour
{
    public ShopData shopData;
    private List<ShopItemData> itemDatas;
    public ItemShopUI prefabItemShopUI;

    public List<ItemShopUI> listItemShopUISpawn;

    private void OnEnable()
    {
        SpawnItem();
    }
    public void SpawnItem()
    {
        itemDatas = shopData.GetTankNotPurchased();
        if (listItemShopUISpawn.Count != 0)
        {
            for (int i = listItemShopUISpawn.Count-1 ; i >= 0; i--)
            {
                ItemShopUI itemShopUI = listItemShopUISpawn[i];
                listItemShopUISpawn.Remove(itemShopUI);
                Destroy(itemShopUI.gameObject);
            }
        }
        for (int i = 0; i < itemDatas.Count; i++)
        {
            ItemShopUI itemShopUISpawn = Instantiate(prefabItemShopUI, transform);
            listItemShopUISpawn.Add(itemShopUISpawn);
            itemShopUISpawn.OnInit(itemDatas[i].id, itemDatas[i].sprite, itemDatas[i].name, itemDatas[i].damage, itemDatas[i].maxHealth, itemDatas[i].speed, itemDatas[i].price);
        }
    }
}

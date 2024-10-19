using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemShopUI : MonoBehaviour
{
    public ShopData shopData;
    private List<ShopItemData> itemDatas;
    public ItemShopUI prefabItemShopUI;

    public List<ItemShopUI> listItemShopUISpawn;
    private void Start()
    {
        SpawnItem();
    }
    public void SpawnItem()
    {
        itemDatas = shopData.itemDatas;
        if(listItemShopUISpawn != null){
            for (int i = 0; i < listItemShopUISpawn.Count; i++)
            {
                Destroy(listItemShopUISpawn[i].gameObject);
            }
        }
        for (int i = 0; i < itemDatas.Count; i++)
        {
          ItemShopUI itemShopUISpawn =  Instantiate(prefabItemShopUI,transform);
          listItemShopUISpawn.Add(itemShopUISpawn);
          itemShopUISpawn.OnInit(itemDatas[i].sprite,itemDatas[i].name,itemDatas[i].damage,itemDatas[i].maxHealth,itemDatas[i].speed,itemDatas[i].price);
        }
    }
}

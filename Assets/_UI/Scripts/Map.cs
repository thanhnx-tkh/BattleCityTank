using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : UICanvas
{
    [SerializeField] private List<ItemMap> itemMaps;
    private void Start() {
        
    }
    private void OnEnable() {
        transform.SetAsFirstSibling();
        LoadMap();
    }
    public void LoadMap(){
        for (int i = 0; i < itemMaps.Count; i++)
        {
            itemMaps[i].indexLevel = i;
            if(DataManager.Ins.GetUnlockLevel().Contains(i)){
                itemMaps[i].Unlock();
                itemMaps[i].isLock = false;
            }
            else{
                itemMaps[i].Lock(); 
                itemMaps[i].isLock = true;
            }
        }
    }


}

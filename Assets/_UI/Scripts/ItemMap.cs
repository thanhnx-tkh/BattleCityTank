using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMap : MonoBehaviour
{
    public int indexLevel;
    public Text textLevel;
    public GameObject lockObj;
    public GameObject unlockObj;
    public Button buttonPlayByLevel;    
    public bool isLock;
    private void Start() {
        buttonPlayByLevel.onClick.AddListener(ButtonPlayByLevel);
    }
    public void Lock(){
        lockObj.SetActive(true);
        unlockObj.SetActive(false);
    }
    public void Unlock(){
        lockObj.SetActive(false);
        unlockObj.SetActive(true);
        textLevel.text = (indexLevel+1).ToString();
    }
    public void ButtonPlayByLevel(){
        if(isLock) return;
        LevelManager.Ins.currentLevel = indexLevel;
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<PlayGame>();
    }
}

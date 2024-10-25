using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWin : MonoBehaviour
{
    private void Start()
    {
        DataManager.Ins.UpdateMoney(300);
        LevelManager.Ins.currentLevel = DataManager.Ins.UnlockLevel(3);
        UIManager.Ins.OpenUI<UIScneneWin>();
    }
}

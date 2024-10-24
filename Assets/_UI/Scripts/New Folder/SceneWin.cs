using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWin : MonoBehaviour
{
    private void Start()
    {
        DataManager.Ins.UpdateMoney(300);
        UIManager.Ins.OpenUI<UIScneneWin>();
    }
}

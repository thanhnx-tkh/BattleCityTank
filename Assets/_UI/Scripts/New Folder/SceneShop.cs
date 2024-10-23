using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneShop : MonoBehaviour
{
    void Start()
    {
        UIManager.Ins.OpenUI<UIShop>();
    }

}

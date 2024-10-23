using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLose : MonoBehaviour
{
    void Start()
    {
        UIManager.Ins.OpenUI<UISceneLose>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceUI : MonoBehaviour
{
    void Start()
    {
        UIManager.Ins.OpenUI<UIInGame>();
    }

}

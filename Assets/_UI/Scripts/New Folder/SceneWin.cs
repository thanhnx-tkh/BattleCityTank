using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Ins.OpenUI<UIScneneWin>();
    }


}

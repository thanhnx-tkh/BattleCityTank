using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCoin : MonoBehaviour
{
    public Text textCointCount;
    void Update()
    {
        textCointCount.text = DataManager.Ins.GetCurrentMoney().ToString();
    }
}

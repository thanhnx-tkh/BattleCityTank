using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : UICanvas
{
    [SerializeField] private Button buttonShop;

    private void OnEnable() {
        transform.SetAsFirstSibling();
    }
    private void Start() {
        buttonShop.onClick.AddListener(ShopButton);
    }
    public void ShopButton()
    {
        Observer.Notify("ChangeAnimButtonShop");
    }
}

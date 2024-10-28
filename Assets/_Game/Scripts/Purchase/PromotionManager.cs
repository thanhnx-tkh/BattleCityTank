using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class PromotionManager : MonoBehaviour
{
    [SerializeField] private List<PromotionButton> buttons;
    [SerializeField] protected List<CodelessIAPButton> buttonList;

    private void Start()
    {
        foreach (Transform button in transform)
        {
            buttons.Add(button.gameObject.GetComponent<PromotionButton>());
            buttonList.Add(button.gameObject.GetComponent<CodelessIAPButton>());
            button.GetComponent<CodelessIAPButton>().button = button.gameObject.GetComponent<Button>();
            button.GetComponent<CodelessIAPButton>().onPurchaseComplete.AddListener(button.gameObject.GetComponent<PromotionButton>().OnPurchaseComplete);
        }
        Observer.AddObserver("UpdateGold", BuyGold);
    }
    private void BuyGold(object[] datas)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].isBuy)
            {
                buttons[i].BuyCoin();
                buttons[i].isBuy = false;
            }
        }
    }
    private void Update()
    {
        
    }
}

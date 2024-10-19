using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopUI : MonoBehaviour
{
    [SerializeField]private Image icon;
    [SerializeField]private Text textName;
    [SerializeField]private Slider sliderDame;
    [SerializeField]private Text textDame;
    [SerializeField]private Slider sliderHP;
    [SerializeField]private Text textHP;
    [SerializeField]private Slider sliderSpeed;
    [SerializeField]private Text textSpeed;
    [SerializeField]private Text textPrice;

    public void OnInit(Sprite icon,string name, float dame, float hp, float speed,float price){
        this.icon.sprite = icon;
        textName.text = name;
        sliderDame.value = dame;
        textDame.text = dame.ToString(); 

        sliderHP.value = hp;
        textHP.text = hp.ToString();

        sliderSpeed.value = speed;
        textSpeed.text = speed.ToString();

        textPrice.text = price.ToString();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCollect : MonoBehaviour
{
    public float timeHours;
    public Text timerText; // Text UI để hiển thị thời gian
    private DateTime targetTime; // Thời gian kết thúc
    private TimeSpan timeRemaining; // Thời gian còn lại
    [SerializeField] private int value;
    public Text valueText;
    public Button collect;
    public GameObject buttonCollectAffter;
    public GameObject buttonCollect;

    void Start()
    {
        targetTime = DateTime.Now.AddHours(timeHours);
        SetTextValue();
        collect.onClick?.AddListener(ButtonCollect);
    }

    void Update()
    {
        timeRemaining = targetTime - DateTime.Now;
        // Nếu thời gian kết thúc, không để thời gian âm
        if (timeRemaining.TotalSeconds > 0)
        {
            // Hiển thị thời gian còn lại theo định dạng giờ:phút:giây
            timerText.text = string.Format("After:{0:D2}:{1:D2}:{2:D2}",
                                           timeRemaining.Hours,
                                           timeRemaining.Minutes,
                                           timeRemaining.Seconds);
        }
        else
        {
            timerText.enabled = false;
            buttonCollectAffter.SetActive(false);
        }
    }
    private void SetTextValue()
    {
        value = UnityEngine.Random.Range(200, 1000);
        valueText.text = value.ToString();
        buttonCollect.SetActive(timeRemaining.TotalSeconds <= 0);
    }
    public void ButtonCollect()
    {
        if (timeRemaining.TotalSeconds <= 0)
        {
            DataManager.Ins.UpdateMoney(value);
            targetTime = DateTime.Now.AddHours(timeHours);
            timerText.enabled = true;
            SetTextValue();
        }
    }
}

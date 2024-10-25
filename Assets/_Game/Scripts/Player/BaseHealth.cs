using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseHealth : Health
{
    public UnityEvent<string> onLose;
    public static BaseHealth Instance;
    private void Awake()
    {
        if(Instance != null)
            Destroy(this);
        else
            Instance = this;
    }
    public override void Dead()
    {
        base.Dead();
        onLose?.Invoke(Const.uiLose);
        this.gameObject.SetActive(false);
    }
}

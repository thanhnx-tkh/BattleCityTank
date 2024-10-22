using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseHealth : Health
{
    public UnityEvent<string> onLose;
    public override void Dead()
    {
        base.Dead();
        onLose?.Invoke(Const.uiLose);
        this.gameObject.SetActive(false);
    }
}

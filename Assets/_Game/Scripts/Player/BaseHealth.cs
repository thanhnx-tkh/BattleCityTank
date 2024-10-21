using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : Health
{
    public override void Dead()
    {
        base.Dead();
        UIGamePlay.Ins.UiEnable(Const.uiLose);
        this.gameObject.SetActive(false);
    }
}

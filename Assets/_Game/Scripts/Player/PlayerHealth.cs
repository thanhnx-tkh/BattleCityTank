using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void Dead()
    {
        if(isDead)
            Destroy(gameObject);
        if (SpawnPlayer.Ins.lifeCount <= 0 )
            UIGamePlay.Ins.UiEnable(Const.uiLose);
    }
}

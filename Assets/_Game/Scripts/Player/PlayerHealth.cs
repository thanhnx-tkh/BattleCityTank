using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public UnityEvent<string> onSpawn;
    public override void Dead()
    {
        if(isDead)
            Destroy(gameObject);
        if (SpawnPlayer.Ins.lifeCount <= 0 )
            onSpawn?.Invoke(Const.uiLose);
    }
}

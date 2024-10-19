using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : IState<EnemyController>
{

    float countTime;
    public void OnEnter(EnemyController enemy)
    {
        countTime = 0;
        enemy.Fire();
    }

    public void OnExecute(EnemyController enemy)
    {
        countTime += Time.deltaTime;
        if (countTime > enemy.fireDelayTime)
        {
            enemy.ChangeState(enemy.runState);
        }
    }

    public void OnExit(EnemyController enemy)
    {
        
    }
}

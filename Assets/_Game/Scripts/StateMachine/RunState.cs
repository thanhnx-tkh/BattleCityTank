using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState<EnemyController>
{
    float countTime;
    public void OnEnter(EnemyController enemy)
    {
        countTime = 0;
        enemy.Rotate(enemy.randomDirection);
    }

    public void OnExecute(EnemyController enemy)
    {
        countTime += Time.deltaTime;
        if (enemy.checkBox.isTouched)
        {
            enemy.ResetMove();
        }
        if (countTime > enemy.moveDelayTime)
        {
            enemy.ChangeState(enemy.fireState);
        }
    }

    public void OnExit(EnemyController enemy)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    public bool isTouched;
    private void OnTriggerEnter(Collider tank)
    {
        if (tank.CompareTag(Const.borderTag) || tank.CompareTag(Const.obstacleTag)
            || tank.CompareTag(Const.enemyTag))
        {
            isTouched = true;
        }
    }

    private void OnTriggerExit(Collider tank)
    {
        if (tank.CompareTag(Const.borderTag) || tank.CompareTag(Const.obstacleTag)
            || tank.CompareTag(Const.enemyTag))
        {
            isTouched = false;
        }
    }
}

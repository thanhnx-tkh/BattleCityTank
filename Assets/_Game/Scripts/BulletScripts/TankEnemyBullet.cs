using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyBullet : BaseBullet
{
    private Health health;
    private float dame;
    private UnityEngine.GameObject wall;
    private void OnTriggerEnter(Collider TankBullet)
    {
        //Debug.Log(TankBullet.gameObject.name);
        if (TankBullet.CompareTag(Const.playerTag))
        {
            health = TankBullet.GetComponent<Health>();
            health.TakeDame(dame);
        }
        if (TankBullet.CompareTag(Const.wallTag))
        {
            gameObject.SetActive(false);
        }
    }
}

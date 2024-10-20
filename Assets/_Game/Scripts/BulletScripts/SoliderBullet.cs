using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderBullet : BaseBullet
{
    private Health health;
    private float dame;
    private UnityEngine.GameObject wall;
    private void OnTriggerEnter(Collider SoliderBullet)
    {
        if (SoliderBullet.CompareTag(Const.playerTag))
        {
            health = SoliderBullet.GetComponent<Health>();
            health.TakeDame(dame);
        }
        if (SoliderBullet.CompareTag(Const.wallTag))
        {
            gameObject.SetActive(false);
        }
    }
}

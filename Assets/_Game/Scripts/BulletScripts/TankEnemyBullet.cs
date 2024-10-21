using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyBullet : BaseBullet
{
    private Coroutine bullets;
    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag(Const.baseTag) || bullet.CompareTag(Const.playerTag))
        {
            health = bullet.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDame(dame);
                SimplePool.Despawn(this);
            }
        }
        if (bullet.CompareTag(Const.borderTag))
        {
            bullets = StartCoroutine(DisableBullet());
        }
        if (bullet.CompareTag(Const.wallTag) || bullet.CompareTag(Const.obstacleTag))
        {

            SimplePool.Despawn(this);
        }
    }
    private IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        StopCoroutine(bullets);
    }
}

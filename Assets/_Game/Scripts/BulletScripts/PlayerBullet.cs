using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet: BaseBullet
{
    private Coroutine bullets;
    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag(Const.enemyTag))
        {
            health = bullet.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDame(dame);
                SimplePool.Despawn(this);
            }
        }
        if (bullet.CompareTag(Const.obstacleTag) || bullet.CompareTag(Const.wallTag))
        {
            SimplePool.Despawn(this);
        }
        if (bullet.CompareTag(Const.borderTag))
        {
            bullets = StartCoroutine(DisableBullet());
        }
    }
    private IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        StopCoroutine(bullets);
    }
}

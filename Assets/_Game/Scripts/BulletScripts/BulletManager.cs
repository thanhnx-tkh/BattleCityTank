using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    public BulletsData bullets;
    public BaseBullet GetBulletType(TypeBullet bulletType)
    {
        BulletData bulletIns = bullets.bulletData.Find(bullet => bullet.baseBullet.GetComponent<BaseBullet>().TypeBullet == bulletType);
        return bulletIns?.baseBullet.GetComponent<BaseBullet>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public override void Dead()
    {
        if(isDead)
            Destroy(gameObject);
    }
}

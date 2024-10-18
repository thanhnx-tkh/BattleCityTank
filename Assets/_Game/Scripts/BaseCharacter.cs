using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float dame;
    [SerializeField] protected float attackSpeed;

    protected virtual void Move()
    {

    }
    protected virtual void Fire()
    {

    }
}

using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [field: SerializeField] public float moveSpeed { get; set; }
    [field: SerializeField] public float dame { get; set; }
    [field: SerializeField] public float attackSpeed;
    [SerializeField] protected ParticleSystem effectHit;
    public virtual void Move()
    {
        
    }
    public virtual void Fire()
    {

    }
}

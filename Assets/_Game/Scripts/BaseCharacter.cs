using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [field: SerializeField] public float moveSpeed { get; set; }
    [field: SerializeField] public float dame { get; set; }
    [field: SerializeField] public float attackSpeed;
    [SerializeField] protected ParticleSystem[] effectHit;
    [SerializeField] protected ParticleSystem shotEffect;
    private void Start()
    {

    }
    public virtual void Move()
    {
        
    }
    public virtual void Fire()
    {

    }
    protected virtual void Effect()
    {
        ParticleSystem hit1 = Instantiate(effectHit[0], transform.position, transform.rotation);
        ParticleSystem hit2 = Instantiate(effectHit[1], transform.position, transform.rotation);
        hit1.Play();
        hit2.Play();
        Destroy(hit1, 1f);
        Destroy(hit2, 1f);
    }
}

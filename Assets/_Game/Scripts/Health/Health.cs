using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxHealth { get; set; }
    [SerializeField] public float health { get; set; }

    public bool isDead => health <= 0;

    private void Awake()
    {
        health = maxHealth;
    }
    public virtual void TakeDame(float dame)
    {
        if (isDead) return;
        health -= dame;
    }
    public virtual void Dead()
    {

    }
}

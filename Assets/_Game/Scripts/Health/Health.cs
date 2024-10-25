using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float maxHealth { get; set; }
    [field: SerializeField] public float health { get; set; }

    public UnityEvent<float, float> onHealthChange;
    public bool isDead => health <= 0;

    private void Start()
    {
        health = maxHealth;
    }
    public virtual void TakeDame(float dame)
    {
        if (isDead) return;
        health -= dame;
        onHealthChange?.Invoke(health,maxHealth);
        if (isDead)
            Dead();
    }
    public virtual void Dead()
    {
        Destroy(this.gameObject);
    }
}

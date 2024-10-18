using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxHealth { get; set; }
    [SerializeField] public float health { get; set; }
    public bool isDead => health <= 0;

    private void Start()
    {
        health = maxHealth;
    }
    
}

using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float dame;
    [SerializeField] public float attackSpeed;
    public virtual void Move(){
        
    }
    public virtual void Fire()
    {

    }
}

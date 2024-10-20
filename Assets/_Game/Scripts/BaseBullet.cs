using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeBullet
{
    Player,
    Enemy,
    Solider
}
public class BaseBullet : GameUnit
{
    [field: SerializeField] public float Id { get; set; }
    [field: SerializeField] public TypeBullet TypeBullet { get; set; }
    [field: SerializeField] public float Speed { get; set; }

    [SerializeField] private AudioSource audioFire;
    [SerializeField] private Rigidbody rb;

    private void OnDrawGizmosSelected()
    {
        rb = GetComponent<Rigidbody>();
        audioFire = GetComponent<AudioSource>();
    }
    private void Start()
    {
        rb.useGravity = false;
    }
    public void OnInit(Vector3 direction)
    {
        rb.velocity = direction * Speed;
        audioFire.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // to do : logic Player
            Debug.Log("Player");
        }
        if (other.CompareTag(Const.obstacleTag) || other.CompareTag(Const.borderTag))
        {
            // to do : logic Enemy
            Debug.Log("Obstacle");
            SimplePool.Despawn(this);
            
        }
        if (other.CompareTag(Const.wallTag))
        {
            // to do : logic wall
            Debug.Log("Wall");
        }
    }

}

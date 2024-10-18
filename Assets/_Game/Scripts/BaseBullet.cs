using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeBullet
{
    Player,
    Enemy
}
public class BaseBullet : MonoBehaviour
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
        //OnInit(Vector3.forward);
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
        if (other.CompareTag("Enemy"))
        {
            // to do : logic Enemy
            Debug.Log("Enemy");
        }
        if (other.CompareTag("Wall"))
        {
            // to do : logic wall
            Debug.Log("Wall");
        }
    }

}

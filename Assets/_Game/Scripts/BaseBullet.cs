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
    [SerializeField] protected float dame;
    [SerializeField] private AudioSource audioFire;
    [SerializeField] private Rigidbody rb;
    [SerializeField] protected AudioSource hitSound;
    protected Health health;
    private Coroutine bullets;
    private void OnDrawGizmosSelected()
    {
        rb = GetComponent<Rigidbody>();
        audioFire = GetComponent<AudioSource>();
    }
    private void Start()
    {
        rb.useGravity = false;
        rb = GetComponent<Rigidbody>();
        audioFire = GetComponent<AudioSource>();
        hitSound = GameObject.FindGameObjectWithTag("HitSound").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag(Const.wallTag) || bullet.CompareTag(Const.obstacleTag)
            || bullet.CompareTag(Const.baseTag) || bullet.CompareTag(Const.playerTag)
            || bullet.CompareTag(Const.enemyTag))
        {
            GameObject hit = Instantiate(hitSound.gameObject, bullet.transform.position, bullet.transform.rotation);
            hit.GetComponent<AudioSource>().Play();
            Destroy(hit,1f);
        }
    }
    public void OnInit(Vector3 direction, float _dame)
    {
        rb.velocity = direction * Speed;
        audioFire.Play();
        this.dame = _dame;
    }
}

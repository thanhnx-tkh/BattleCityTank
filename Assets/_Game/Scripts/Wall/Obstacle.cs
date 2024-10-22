using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject effectHit;
    [SerializeField] private AudioSource hitSound;
    private void Start()
    {
        hitSound = GameObject.FindGameObjectWithTag("HitSound").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.CompareTag(Const.bulletTag) || obstacle.CompareTag(Const.bulletPlayerTag))
        {
            GameObject effect = Instantiate(effectHit, obstacle.transform.position, obstacle.transform.rotation);
            Destroy(effect, 1f);
        }
    }
}

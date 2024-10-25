using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] private AudioSource alarmSound;
    [SerializeField] private GameObject shieldOn;
    private Coroutine shieldTime;
    private void Start()
    {
        alarmSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.bulletTag))
        {
            alarmSound.Play();
        }
    }
    private void EnableShield()
    {
        if (UiBonnus.Instance.isShield)
        {
            shieldOn?.SetActive(true);
            shieldTime = StartCoroutine(DisableShield());
            BaseHealth.Instance.TakeDame(0);
        }
        else
            return;
    }
    private IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(10f);
        shieldOn?.SetActive(false);
        UiBonnus.Instance.isShield = false;
        StopCoroutine(shieldTime);
    }
    private void Update()
    {
        EnableShield();
    }
}

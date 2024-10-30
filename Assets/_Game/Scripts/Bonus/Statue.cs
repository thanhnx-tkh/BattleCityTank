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
        Observer.AddObserver("Shield", EnableShield);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.bulletTag))
        {
            alarmSound.Play();
        }
    }
    private void EnableShield(object[] datas)
    {
        shieldOn?.SetActive(true);
        BaseHealth.Instance.TakeDame(0);
        shieldTime = StartCoroutine(DisableShield());
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

    }
}

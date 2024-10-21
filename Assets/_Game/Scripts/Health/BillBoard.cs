using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillBoard : MonoBehaviour
{
    [SerializeField] private Slider healthFill;
    [SerializeField] private Health health;
    private Transform camMain;
    private void Start()
    {
        camMain = Camera.main.transform;
        health = GetComponentInParent<Health>();
        health.onHealthChange.AddListener(UpdateHealth);
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + camMain.forward);
    }

    public void UpdateHealth(float healthPoint, float maxHealth)
    {
        healthFill.value = healthPoint / maxHealth;
    }
}

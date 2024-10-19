using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [field: SerializeField] public List<BaseWave> waves;
    private void Start()
    {
        waves[0].gameObject.SetActive(true);
    }
    public void SettingSpawn()
    {
        if (waves[0] != null) return;
        waves[0].gameObject.SetActive(false);
        waves[1].gameObject.SetActive(true);
        if (waves[1] != null) return;
        waves[1].gameObject.SetActive(false);
    }
    private void Update()
    {
        SettingSpawn();
    }
}

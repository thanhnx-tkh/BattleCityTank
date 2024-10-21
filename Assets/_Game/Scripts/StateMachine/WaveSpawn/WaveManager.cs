using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField] private List<BaseWave> waves;
    [SerializeField] private GameObject fireWork;
    public int countWave;
    public int totalWave;
    public UnityEvent<float, float> onWaveChange;
    private void Start()
    {
        waves[0].gameObject.SetActive(true);
        totalWave = waves[0].spawnsTransform.Count + waves[1].spawnsTransform.Count;
        countWave = waves[0].spawnsTransform.Count + waves[1].spawnsTransform.Count;
    }
    public void SettingSpawn()
    {
        if (waves[1] != null)
            waves[1].gameObject.SetActive(waves[0] == null);
        onWaveChange?.Invoke(countWave, totalWave);
        if (countWave <= 0)
        {
            fireWork.SetActive(true);
        }
    }
    private void Update()
    {
        SettingSpawn();
    }
}

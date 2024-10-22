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
    private void Awake()
    {
        foreach (Transform wave in transform)
        {
            waves.Add(wave.GetComponent<BaseWave>());
        }
    }
    private void Start()
    {
        waves[0].gameObject.SetActive(true);
        countWave = waves[0].tankEnemy.Count * waves.Count;
        totalWave = waves[0].tankEnemy.Count * waves.Count;
    }
    public void SettingSpawn()
    {
        for (int i = waves.Count - 1; i >= 0; i--)
        {
            if (countWave <= 0)
            {
                fireWork.SetActive(true);
                break;
            }
            if (waves[0] == null)
            {
                waves.RemoveAt(0);
            }
            if (waves[0] != null)
            {
                waves[0].gameObject.SetActive(true);
            }
        }
        onWaveChange?.Invoke(countWave, totalWave);
    }
    private void Update()
    {
        SettingSpawn();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<BaseWave> waves;
    public int countWave;
    public UnityEvent<float, float> onWaveChange;
    private void Start()
    {
        waves[0].gameObject.SetActive(true);   
    }
    public void SettingSpawn()
    {
        if (waves[0] == null)
        {
            waves[1].gameObject.SetActive(true);
        }
        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i] == null)
            {
                waves.RemoveAt(i);
            }
        }
        countWave = waves.Count;
        onWaveChange?.Invoke(countWave, 2);
    }
    private void Update()
    {
        SettingSpawn();
    }
}

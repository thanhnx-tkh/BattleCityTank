using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<BaseWave> waves;
    [SerializeField] private GameObject fireWork;
    public int countWave;
    public int totalWave;
    public UnityEvent<float, float> onWaveChange;
    public UnityEvent<int> onCountChange;

    public static WaveManager Instance {  get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
            Instance = this;
    }

    private void Start()
    {
        foreach (Transform wave in transform)
        {
            waves.Add(wave.GetComponent<BaseWave>());
        }
        waves[0].gameObject.SetActive(true);
        waves[0].SpawnEnemy();
        countWave = waves[0].gameObject.GetComponent<BaseWave>().tankEnemy.Count * waves.Count;
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
                waves[0].SpawnEnemy();
            }
        }
        onWaveChange?.Invoke(countWave, totalWave);
        onCountChange?.Invoke(countWave);
    }
    private void Update()
    {
        SettingSpawn();
    }
}

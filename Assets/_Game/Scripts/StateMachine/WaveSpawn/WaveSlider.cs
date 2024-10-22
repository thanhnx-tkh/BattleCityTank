using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSlider : MonoBehaviour
{
    [SerializeField] private Slider wavebar;
    [SerializeField] private WaveManager waveManager;
    private void Start()
    {
        waveManager.onWaveChange.AddListener(UpdateWavebar);
        waveManager = GameObject.FindGameObjectWithTag(Const.spamWaveTag).GetComponent<WaveManager>();
    }
    public void UpdateWavebar(float wave, float maxWave)
    {
        wavebar.value = wave / maxWave;
    }
}

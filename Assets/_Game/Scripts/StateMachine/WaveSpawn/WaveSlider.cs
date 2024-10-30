using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSlider : MonoBehaviour
{
    [SerializeField] private Slider wavebar;
    //[SerializeField] private WaveManager waveManager;
    private void Start()
    {
        WaveManager.Instance.onWaveChange.AddListener(UpdateWavebar);
    }
    public void UpdateWavebar(float wave, float maxWave)
    {
        wavebar.value = wave / maxWave;
    }
}

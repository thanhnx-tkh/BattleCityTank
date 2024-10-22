using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWave : MonoBehaviour
{
    [SerializeField] public List<GameObject> tankEnemy;
    [SerializeField] public List<Transform> spawnsTransform;
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected GameObject effectSpawn;
    [SerializeField] protected float timeDestroyEffect;
    [SerializeField] protected WaveManager waveManager;
    private void Awake()
    {
        SpawnEnemy();
    }
    private void Start()
    {
        waveManager = GameObject.FindGameObjectWithTag(Const.spamWaveTag).GetComponent<WaveManager>();
        waveManager.onCountChange?.AddListener(ClearEnemy);
    }
    protected virtual void SpawnEnemy()
    {
        for (int i = spawnsTransform.Count - 1; i >= 0; i--)
        {
            GameObject tank = Instantiate(enemyPrefab, spawnsTransform[i].position, spawnsTransform[i].rotation);
            tank.transform.SetParent(spawnsTransform[i].gameObject.transform);
            GameObject effect = Instantiate(effectSpawn, spawnsTransform[i].position, spawnsTransform[i].rotation);
            tankEnemy.Add(tank);
            Destroy(effect, timeDestroyEffect);
            spawnsTransform.RemoveAt(i);
        }
    }
    protected void ClearEnemy(int countTank)
    {
        for (int i = 0; i < tankEnemy.Count; i++)
        {
            if (tankEnemy[i] == null)
            {
                tankEnemy.RemoveAt(i);
                countTank--;
            }
        }
        if (tankEnemy.Count == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        ClearEnemy(waveManager.countWave);
    }
}

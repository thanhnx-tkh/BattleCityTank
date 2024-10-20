using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : BaseWave
{
    private void Start()
    {
        SpawnEnemy();
    }
    protected override void SpawnEnemy()
    {
        for (int i = spawnsTransform.Count - 1; i >= 0; i--)
        {
            UnityEngine.GameObject tank = Instantiate(enemyPrefab, spawnsTransform[i].position, spawnsTransform[i].rotation);
            tank.transform.SetParent(spawnsTransform[i].gameObject.transform);
            UnityEngine.GameObject effect = Instantiate(effectSpawn, spawnsTransform[i].position, spawnsTransform[i].rotation);
            tankEnemy.Add(tank);
            Destroy(effect, timeDestroyEffect);
        }
    }
}

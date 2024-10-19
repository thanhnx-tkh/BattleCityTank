using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWave : MonoBehaviour
{
    [field: SerializeField] public List<GameObject> tankEnemy { get; private set; }
    [field: SerializeField] public List<Transform> spawnsTransform;
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected GameObject effectSpawn;
    [SerializeField] protected float timeDestroyEffect;
    protected virtual void SpawnEnemy()
    {

    }
}

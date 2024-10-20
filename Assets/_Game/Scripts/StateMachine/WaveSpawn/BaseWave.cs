using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWave : MonoBehaviour
{
    [field: SerializeField] public List<UnityEngine.GameObject> tankEnemy { get; private set; }
    [field: SerializeField] public List<Transform> spawnsTransform;
    [SerializeField] protected UnityEngine.GameObject enemyPrefab;
    [SerializeField] protected UnityEngine.GameObject effectSpawn;
    [SerializeField] protected float timeDestroyEffect;
    protected virtual void SpawnEnemy()
    {

    }
}

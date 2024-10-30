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
    private void Start()
    {
        Observer.AddObserver("ClearEnemy", ClearEnemy);
    }
    public void SpawnEnemy()
    {
        for (int i = spawnsTransform.Count - 1; i >= 0; i--)
        {
            GameObject tank = Instantiate(enemyPrefab, spawnsTransform[i].position, spawnsTransform[i].rotation);
            tank.transform.SetParent(spawnsTransform[i].gameObject.transform);
            GameObject effect = Instantiate(effectSpawn, spawnsTransform[i].position, spawnsTransform[i].rotation);
            SetIndex(tank);
            tankEnemy.Add(tank);
            Destroy(effect, timeDestroyEffect);
            spawnsTransform.RemoveAt(i);
        }
    }
    protected virtual void SetIndex(GameObject tanks)
    {
        if (LevelManager.Ins.currentLevel > 0)
        {
            if (tanks.GetComponent<Health>().maxHealth >= 800 || tanks.GetComponent<EnemyController>().dame >= 500
                || tanks.GetComponent<EnemyController>().moveSpeed >= 3) return;
            tanks.GetComponent<Health>().maxHealth += LevelManager.Ins.currentLevel * 50;
            tanks.GetComponent<EnemyController>().dame += LevelManager.Ins.currentLevel * 20;
            tanks.GetComponent<EnemyController>().moveSpeed += LevelManager.Ins.currentLevel * 0.1f;
            if(LevelManager.Ins.currentLevel >= 6)
                tanks.GetComponent<EnemyController>().moveSpeed += LevelManager.Ins.currentLevel * 0.2f;
        }
    }
    protected void ClearEnemy(object[] datas)
    {
        for (int i = 0; i < tankEnemy.Count; i++)
        {
            if (tankEnemy[i].GetComponent<Health>().isDead)
            {
                tankEnemy.RemoveAt(i);
                WaveManager.Instance.countWave--;
            }
        }
        if (tankEnemy.Count == 0)
        {
           this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        
    }
}

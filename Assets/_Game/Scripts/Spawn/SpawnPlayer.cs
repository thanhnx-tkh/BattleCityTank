using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPlayer;
    [field: SerializeField] public int lifeCount { get; set; }
    private PlayerHealth playerHealth;
    public UnityEvent<int> onLifeChange;
    public UnityEvent<string> onSpawn;


    public static SpawnPlayer _ins;

    private void Awake()
    {
        if (_ins != null)
        {
            Destroy(gameObject);
        }
        else
            _ins = this;
    }
    protected void Start()
    {
        FirstSpawn();
    }
    public void FirstSpawn()
    {
        GameObject playerIns = Instantiate(player, spawnPlayer.position, spawnPlayer.rotation);
        playerIns.transform.SetParent(this.transform);
        playerHealth = playerIns.GetComponent<PlayerHealth>();
    }
    public void SpawnLife()
    {
        if (playerHealth.isDead && lifeCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FirstSpawn();
                playerHealth.health = playerHealth.maxHealth;
                lifeCount--;
                onLifeChange?.Invoke(lifeCount);

            }
        }
        if (playerHealth.isDead && lifeCount <= 0)
        {
            onSpawn?.Invoke(Const.uiLose);

        }
    }
    private void Update()
    {
        SpawnLife();
    }
}

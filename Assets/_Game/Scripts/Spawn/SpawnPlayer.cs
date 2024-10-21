using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : Singleton<SpawnPlayer>
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPlayer;
    [SerializeField] private Text lifeText;
    [field: SerializeField] public int lifeCount { get; set; }
    private PlayerHealth playerHealth;

    private void Awake()
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
                playerHealth.health = playerHealth.maxHealth;
                GameObject playerIns = Instantiate(player, spawnPlayer.position, spawnPlayer.rotation);
                playerIns.transform.SetParent(this.transform);
                lifeCount--;
                lifeText.text = lifeCount.ToString();
            }
        }
    }
    private void Update()
    {
        SpawnLife();
    }
}

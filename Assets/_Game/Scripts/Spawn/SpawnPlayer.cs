using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject prefabTank;
    [SerializeField] private Transform spawnPlayer;
    [SerializeField] private ShopData shopData;
    private GameObject tankInstace;
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
        prefabTank  = shopData.itemDatas[LevelManager.Ins.currentTankId].tankObj;
        tankInstace = Instantiate(prefabTank.gameObject,spawnPlayer.position, spawnPlayer.rotation);
        tankInstace.transform.SetParent(spawnPlayer.transform);
        PlayerController playerController = tankInstace.GetComponent<PlayerController>();
        playerHealth = tankInstace.GetComponent<PlayerHealth>();
        float indexTank = DataManager.Ins.GetTankLevelbyId(LevelManager.Ins.currentTankId);
        if (LevelManager.Ins.currentTankId == 0)
        {
            playerController.dame = shopData.itemDatas[LevelManager.Ins.currentTankId].damage;
            playerController.moveSpeed = (shopData.itemDatas[LevelManager.Ins.currentTankId].speed / 100) + 0.5f;
            playerHealth.maxHealth = shopData.itemDatas[LevelManager.Ins.currentTankId].maxHealth;
        }
        else
        {
            playerController.dame = shopData.itemDatas[LevelManager.Ins.currentTankId].damage + (indexTank * 10);
            playerController.moveSpeed = (shopData.itemDatas[LevelManager.Ins.currentTankId].speed + (indexTank * 10)) / 100;
            playerHealth.maxHealth = shopData.itemDatas[LevelManager.Ins.currentTankId].maxHealth + (indexTank * 10);
        }

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

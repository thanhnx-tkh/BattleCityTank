using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private PlayerData playerData;
    private SaveSystem saveSystem;
    private void OnEnable() {
        saveSystem = GetComponent<SaveSystem>();
        LoadData();
        SaveGame();
        Observer.Notify("UpdateUI");
        LevelManager.Ins.currentTankId = GetListPurchasedTankById()[GetListPurchasedTankById().Count - 1];
    }
    public void SaveGame()
    {
        saveSystem.SavePlayerData(playerData);
    }
    public void LoadData()
    {
        playerData = saveSystem.LoadPlayerData();
    }

    public void PurchaseTank(int tankId)
    {
        if (!playerData.purchasedTankIds.Contains(tankId))
        {
            playerData.purchasedTankIds.Add(tankId);
            playerData.tankLevels.Add(1);
            Debug.Log("Purchased Tank ID: " + tankId);
        }
        else
        {
            Debug.Log("Tank ID: " + tankId + " đã được mua rồi.");
        }
        SaveGame();
    }

    public void UpgradeTank(int tankId)
    {
        int index = playerData.purchasedTankIds.IndexOf(tankId);
        if (index != -1)
        {
            playerData.tankLevels[index] += 1;
        }
        else
        {
            Debug.LogWarning("Tank ID: " + tankId + " chưa được mua.");
        }

        SaveGame();
    }

    public void UpdateMoney(int amount)
    {
        playerData.currentMoney += amount;
        Debug.Log("Updated Money: " + playerData.currentMoney);

        SaveGame();
    }
    public void UpdateMoneyBuyTank(int amount)
    {
        playerData.currentMoney -= amount;
        Debug.Log("Updated Money: " + playerData.currentMoney);

        SaveGame();
    }

    public int UnlockLevel(int star)
    {
        int level = playerData.unlockedLevels.Count;
        if (!playerData.unlockedLevels.Contains(level))
        {
            playerData.unlockedLevels.Add(level);
            playerData.starLevels.Add(star);
            Debug.Log("Unlocked Level: " + level);
        }
        else
        {
            Debug.Log("Level: " + level + " đã được mở.");
        }

        SaveGame();
        return level;
    }
    public List<int> GetListPurchasedTankById()
    {
        LoadData();
        return playerData.purchasedTankIds;
    }
    public int GetTankLevelbyId(int id)
    {
        LoadData();
        int index = playerData.purchasedTankIds.IndexOf(id);
        return playerData.tankLevels[index];
    }

    public float GetStarByLevel(int indexLevel)
    {
        LoadData();
        int index = playerData.unlockedLevels.IndexOf(indexLevel);
        return playerData.starLevels[index];
    }
    public int GetCurrentMoney()
    {
        LoadData();
        return playerData.currentMoney;
    }

    public List<int> GetUnlockLevel()
    {
        LoadData();
        return playerData.unlockedLevels;
    }

    public float GetCurrentScore()
    {
        LoadData();
        return playerData.currentScore;
    }
}

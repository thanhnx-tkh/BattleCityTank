using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        string directoryPath = Application.dataPath + "/_DataPlayer";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        filePath = directoryPath + "/playerData.json";
    }

    public void SavePlayerData(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData, true); 
        File.WriteAllText(filePath, json);
        Debug.Log("Player data saved to: " + filePath);
    }

    public PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath); 
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);  
            Debug.Log("Data loaded from: " + filePath);
            return playerData;
        }
        else
        {
            Debug.LogWarning("Save file not found at: " + filePath);
            return new PlayerData();
        }
    }
}

using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        #if UNITY_EDITOR
            string directoryPath = Application.dataPath;  // Đường dẫn dễ tìm trong Editor
        #else
            string directoryPath = Application.persistentDataPath;  // Đường dẫn khi chạy trên Android
        #endif
        
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Đặt đường dẫn file JSON
        filePath = Path.Combine(directoryPath, "playerData.json");

        Debug.Log("File path set to: " + filePath);
    }

    public void SavePlayerData(PlayerData playerData)
    {
        try
        {
            // Chuyển đổi object PlayerData thành JSON
            string json = JsonUtility.ToJson(playerData, true);

            // Ghi JSON vào file
            File.WriteAllText(filePath, json);
            Debug.Log("Player data saved to: " + filePath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to save player data: " + ex.Message);
        }
    }

    public PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            try
            {
                // Đọc nội dung file JSON
                string json = File.ReadAllText(filePath);

                // Chuyển đổi JSON thành object PlayerData
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

                Debug.Log("Data loaded from: " + filePath);
                return playerData;
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Failed to load player data: " + ex.Message);
                return new PlayerData();  // Trả về object PlayerData mặc định
            }
        }
        else
        {
            Debug.LogWarning("Save file not found at: " + filePath);
            return new PlayerData();  // Trả về object PlayerData mặc định nếu không tìm thấy file
        }
    }
}

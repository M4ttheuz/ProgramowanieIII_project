using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string saveFilePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        saveFilePath = Path.Combine(Application.dataPath, "save.json");
    }

    public void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
    }

    public GameData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }

        Debug.LogWarning("Save file not found. Returning default data.");
        return new GameData();
    }
}

[System.Serializable]
public class GameData
{
    public int tanksDestroyed;
    public int playedBattles;
}

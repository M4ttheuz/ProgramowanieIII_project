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
            DontDestroyOnLoad(gameObject);
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
        Debug.Log("Game Saved: " + saveFilePath);
    }

    public GameData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game Loaded");
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
<<<<<<< HEAD
    public int playedBattles;
=======
    public int playedTime;
>>>>>>> 6ef7eedccadd52639a0f336e41b852cd084f379a
}

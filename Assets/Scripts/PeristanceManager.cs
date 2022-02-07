using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PeristanceManager : MonoBehaviour
{
    public static PeristanceManager Instance;

    public string newPlayer;
    public string playerName;
    public int points;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int points;
    }
     

    public void SavePlayersName(string playerN)
    {
        playerName = playerN;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.points = points;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            points = data.points;
        }
    }

}

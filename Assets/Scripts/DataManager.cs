using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string playerBestName;
    public int playerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class DataBestPlayer
    {
        public string name;
        public int score;
        public DataBestPlayer(string _name, int _score)
        {
            name = _name;
            score = _score;
        }
    }

    public void SaveScore(int score)
    {
        DataBestPlayer dataBestPlayer = new DataBestPlayer(playerName, score);
        string json = JsonUtility.ToJson(dataBestPlayer);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json",json);

    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string dataJson = File.ReadAllText(path);
            DataBestPlayer dataBestPlayer = JsonUtility.FromJson<DataBestPlayer>(dataJson);
            playerBestName = dataBestPlayer.name;
            playerScore = dataBestPlayer.score;
        }
    }

    public string GetData()
    {
        if(!playerBestName.Equals(""))
            return playerBestName + " - " + playerScore;
        return "";
    }
}

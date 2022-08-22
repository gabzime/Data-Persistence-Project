using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BestScoreManager : MonoBehaviour
{

    public static BestScoreManager Instance;

    public string bestScoreString;
    public int points;
    public string userName;

    private void Awake()
    {
        // Debug.Log("Valor de bestScoreString=" + bestScoreString);
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void recalculate(int newBestScore)
    {
        points = newBestScore;
        bestScoreString = "Best Score:"+userName+":" + points.ToString();
    }

    public void setUserName(string s)
    {
        userName = s;
    }

    [System.Serializable]
    class SaveData
    {
        public string Score;
        public int pointsBestScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Score = bestScoreString;
        data.pointsBestScore = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreString = data.Score;
            points = data.pointsBestScore;
        }
    }

}

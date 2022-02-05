using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string PlayerName;
    public Highscore CurrentHighscore;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighscore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class Highscore
    {
        public string playerName;
        public int score;
    }

    public void SaveHighscore()
    {
        if(CurrentHighscore != null)
        {
            // if there is a current highscore: save it to file
            string path = Application.persistentDataPath + "/highscore.json";
            string json = JsonUtility.ToJson(CurrentHighscore);
            File.WriteAllText(path, json);
        }
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if(File.Exists(path))
        {
            // if a savefile exists: load it
            string json = File.ReadAllText(path);
            CurrentHighscore = JsonUtility.FromJson<Highscore>(json);
        }
        else
        {
            // if there is no file: instantiate empty
            CurrentHighscore = new Highscore() { playerName = "", score = 0 };
        }
    }

    public void UpdateHighscore(int newScore)
    {
        // if the new score is a highscore: update data & save it
        if (newScore > CurrentHighscore.score)
        {
            CurrentHighscore.playerName = PlayerName;
            CurrentHighscore.score = newScore;
            SaveHighscore();
        }
    }
}

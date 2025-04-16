using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        savePath = Path.Combine(Application.persistentDataPath, "highscores.json");
    }

    private string savePath; 
    [System.Serializable]
    public class HighScoreEntry
    {
        public string playerName;
        public int score;
    }
    [System.Serializable]
    public class HighScoreList
    {
        public List<HighScoreEntry> entries = new List<HighScoreEntry>(10);
    }

    public HighScoreList LoadScores()
    {
        try
        {
            if (!File.Exists(savePath)) return new HighScoreList();
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<HighScoreList>(json);
        }
        catch (System.Exception e)
        {
            Debug.LogError("����ʧ��: " + e.Message);
            return new HighScoreList();
        }
    }

    private void SaveScores(HighScoreList data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json); 
    }

    
    public void AddNewScore(string name, int score)
    {
        HighScoreList list = LoadScores();
        list.entries.Add(new HighScoreEntry { playerName = name, score = score });

        list.entries = list.entries
            .OrderByDescending(entry => entry.score)
            .Take(10)
            .ToList();

        SaveScores(list);
    }

    private void InitializeArchiveFile()
    {
        if (!File.Exists(savePath))
        {
            for (int i = 0; i < 10; i++)
            {
                AddNewScore("name", 0);
            }
        }
    }


    void Start()
    {
        InitializeArchiveFile();
    }



    void Update()
    {
        
    }
}

// Sondre, hvis du ser det, lykke til å se den "perfekt" kode
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class LevelProgress
{
    public int levelId;
    public bool unlocked = false;
    public float bestTime = 0f;
    public int stars = 0;
    public LevelProgress(int levelId, bool unlocked, float bestTime, int stars)
    {
        this.levelId = levelId;
        this.unlocked = unlocked;
        this.bestTime = bestTime;
        this.stars = stars;
    }
}
public static class GameManager
{

    static int LEVEL_COUNT = 10;
    static GameManager()
    {
        loadProgress();
    }
    public static List<LevelProgress> progress = new List<LevelProgress>();

    public static void SaveProgress()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levelsData.lol";
        FileStream fs = new FileStream(path, FileMode.Create);

        formatter.Serialize(fs, progress);
        fs.Close();
    }
    public static void loadProgress()
    {
        string path = Application.persistentDataPath + "/levelsData.lol";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            progress = formatter.Deserialize(fs) as List<LevelProgress>;
            fs.Close();

        }
        else
        {
            Debug.LogWarning("File levelsData.lol was not found in " + path + "Making new game");

            progress.Add(new LevelProgress(0, true, 0f, 0));
            for (int i = 0; i < LEVEL_COUNT; i++)
            {
                progress.Add(new LevelProgress(i +1, false, 0f, 0));
            }
        }
    }
}

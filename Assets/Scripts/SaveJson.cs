using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveJson
{
    public static string directory = "/SaveData/";
    public static string filename = "MyData.txt";

    public static void Save(SaveData saveData)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(dir + filename, json);
    }

    public static SaveData Load()
    {
        string fullPath = Application.persistentDataPath + directory + filename;
        SaveData saveData = new SaveData();
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.Log("json does not exist, creating a save file");
            Save(saveData);
        }

        return saveData;
    }
}

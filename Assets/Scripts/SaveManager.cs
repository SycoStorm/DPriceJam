using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager 
{
   public static SaveData dataHolder;
    public static int GetHighScore()
    {
        dataHolder = new SaveData();
        dataHolder =  SaveJson.Load();
        return dataHolder.highScore;
    }

    public static void SavenewScore(SaveData saveData)
    {
        if (saveData != null)
        {
            SaveJson.Save(saveData);
        }
    }
}

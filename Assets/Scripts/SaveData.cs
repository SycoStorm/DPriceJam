using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData 
{
    public List<LevelScoreData> ScoreByLevels;
}

public class UserData
{
   public string level;
   public string userName;
   public string time;
   public string opposites;
   public string same;
   public string totalScore;
}

public class LevelScoreData
{
    public List<UserData> userScores;
}
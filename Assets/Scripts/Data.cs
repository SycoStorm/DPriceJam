using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 2)]
public class Data : ScriptableObject
{
    [SerializeField] int currentLevel = 1;
    [SerializeField] int currentLevelScore = 0;
    [SerializeField] int turn = 0;
    [SerializeField] int maxLevels = 3;

   

    public int Turn
   {
        get
        {
            return turn;
        }

        set  //This keeps keeps the flip turns to only 2 turns no matter what.
        {

            turn = value;
            if(turn > 1)
            {
                turn = 0;
            }
           
           
        }
   }
    public int  GetOverallScore()
    {
        return currentLevelScore;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    public void ResetAllLevelsAndScore()
    {
        currentLevel = 1;
        currentLevelScore = 0;
        if(Turn > 0)
        {
            Turn++;
        }
    }

    public void ChangeNextLevel()
    {

            currentLevel += 1;
            SceneManager.LoadScene("GameScene");

    }

    public void BackToMainMenu()
    {
        ResetAllLevelsAndScore();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnLevelEnd(int score)
    {
        currentLevelScore = score;
        
    }
}

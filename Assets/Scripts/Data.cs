using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 2)]
public class Data : ScriptableObject
{
    [SerializeField] int previousLevel = 0;
    [SerializeField] int currentLevel = 0;
    [SerializeField] int PreviousLevelScore = 0;
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

    public void ResetAllLevelsAndScore()
    {
        currentLevel = 0;
        previousLevel = 0;
        PreviousLevelScore = 0;
        currentLevelScore = 0;
        if(Turn > 0)
        {
            Turn++;
        }
    }

    public void ChangeNextLevel()
    {
        if (currentLevel > maxLevels)
        {
            currentLevel += 1;
            previousLevel = currentLevel - 1;
        }
        else
        {
            FinishedGame();
        }
    }

    void FinishedGame()
    {
        GameActions.FinishGame?.Invoke();
    }
}

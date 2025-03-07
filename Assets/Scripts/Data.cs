using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 2)]
public class Data : ScriptableObject
{
    int previousLevel = 0;
    int currentLevel = 0;

    int turn = 0;

   public int Turn
   {
        get
        {
            return turn;
        }

        set  //This keeps keeps the flip turns to only 2 turns no matter what.
        {
            if(turn == 0)
            {
                turn = 1;
            }
            else
            {
                turn = 0;
            }

           
        }
   }

    public void ResetAllLevels()
    {
        currentLevel = 0;
        previousLevel = 0;
    }

    public void ChangeNextLevel()
    {
        currentLevel += 1;
        previousLevel = currentLevel - 1;
    }
}

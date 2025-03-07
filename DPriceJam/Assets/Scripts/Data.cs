using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 2)]
public class Data : ScriptableObject
{
    string previousLevel;
    string currentLevel;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 3)]
public class LevelData : ScriptableObject
{
    [SerializeField] List<Card> LevelOneCards = new List<Card>();
    [SerializeField] List<Card> LevelTwoCards = new List<Card>();
    [SerializeField] List<Card> LevelThreeCards = new List<Card>();
    [SerializeField] Data gameData;
    int currentLevel;
     public List<Card> GetCardSets()
    {
        Debug.Log($"Current Level is {gameData.GetCurrentLevel()}");
        currentLevel = gameData.GetCurrentLevel();
        switch(currentLevel)
        {
            case 1:
                
                return LevelOneCards;
              
            case 2:
                return LevelTwoCards;
                
            case 3:
                return LevelThreeCards;
               
            default:
                Debug.Log("Levels Only Go To 3");
                return null;
                
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 3)]
public class LevelData : ScriptableObject
{
    [SerializeField] List<Card> LevelOneCards = new List<Card>();
    [SerializeField] List<Card> LevelTwoCards = new List<Card>();
    [SerializeField] List<Card> LevelThreeCards = new List<Card>();

     public List<Card> GetCardSets(int currentLevel)
    {
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/NewCard", order = 1)]

public class Card:ScriptableObject  
{
    [SerializeField] int pointsGained = 1;
    [SerializeField] Sprite sprite;
    [SerializeField] int batchId; //The batch of 4 cards, 2 cards will have a matchID of 1 and 2 cards will have a matchID of 2.  1 and 1 are matches, 2 and 2 are matches, 1 and 2 are opposites.
    [SerializeField] int matchId; // either 1 or 2 
    [SerializeField] int pointsMultiplier = 2;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public int GetBatchID()
    {
        return batchId;
    }

    public int GetMatchId()
    {
        return matchId;
    }

    public int ReturnMatchPointsGain()
    {
        return pointsGained;
    }

    public int ReturnOppositesPointsGain()
    {
        return pointsGained * pointsMultiplier;
    }
}

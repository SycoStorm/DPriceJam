using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int currentLevel = 1;
    [SerializeField] LevelData levelData;
    [SerializeField] List<InGameCard> inPlayCards = new List<InGameCard>();
    [SerializeField] List<Card> cardSetData = new List<Card>();

    private void Awake()
    {
        LoadCardData();
    }
    void Start()
    {    
        PopulateCards();
    }
    void LoadCardData()
    {
        cardSetData.AddRange(levelData.GetCardSets(currentLevel));
        cardSetData.AddRange(levelData.GetCardSets(currentLevel));
    }

    public void PopulateCards()
    {
        int index = 0;
        
        foreach(Card card in cardSetData)
        {
            
            if (index < inPlayCards.Count)
            {
                inPlayCards[index].cardData = card;
            }
            index++;
        }

        for (int i = 0; i < inPlayCards.Count; i++)
        {
            if(inPlayCards[i].cardData == null)
            {
                inPlayCards[i].gameObject.SetActive(false);
            }
        }
    }

    public bool CheckIfAllCardsFlipped()
    {
        bool allFlipped = true;

        foreach(InGameCard inGameCard in inPlayCards)
        {
            if(inGameCard.CheckIfFlipped() == false)
            {
                return false;
            }
        }

        return true;
    }

}

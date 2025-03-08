using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int currentLevel;
    [SerializeField] LevelData levelData;
    [SerializeField] List<InGameCard> inPlayCards = new List<InGameCard>();
    [SerializeField] List<Card> cardSetData = new List<Card>();

    [SerializeField] List<InGameCard> LevelOneVisualCards = new List<InGameCard>();
    [SerializeField] List<InGameCard> LevelTwoVisualCards = new List<InGameCard>();
    [SerializeField] List<InGameCard> LevelThreeVisualCards = new List<InGameCard>();
    private void Awake()
    {
        LoadCardData();
    }
    void Start()
    {
        CheckLevelForVisualSet();
        PopulateCards();
    }
    void LoadCardData()
    {      
            cardSetData.AddRange(levelData.GetCardSets());
            cardSetData.AddRange(levelData.GetCardSets());
            ShuffleDeck();     
       
    }

    public void PopulateCards()
    {      
        int index = 0;

        foreach (Card card in cardSetData)
        {

            if (index < inPlayCards.Count)
            {
                inPlayCards[index].gameObject.SetActive(true);
                if (card.GetSprite() != null)
                {
                    inPlayCards[index].SetCardSprite(card.GetSprite());
                }
                inPlayCards[index].cardData = card;
            }
            index++;
        }

        for (int i = 0; i < inPlayCards.Count; i++)
        {
            if (inPlayCards[i].cardData == null)
            {
                inPlayCards[i].gameObject.SetActive(false);
            }
        }
    }

    public bool CheckIfAllCardsFlipped()
    {
        bool allFlipped = true;

        foreach (InGameCard inGameCard in inPlayCards)
        {
            if (inGameCard.CheckIfFlipped() == false)
            {
                return false;
            }
        }

        return true;
    }

    public void ShuffleDeck()
    {
        var count = cardSetData.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            int r = Random.Range(i, count);
            Card card = cardSetData[i];
            cardSetData[i] = cardSetData[r];
            cardSetData[r] = card;

        }
    }

    public void CheckLevelForVisualSet()
    {
        switch (levelData.GetCurrentLevel())
        {
            case 1:
                if (inPlayCards.Count == 0)
                {
                    inPlayCards.AddRange(LevelOneVisualCards);
                }
                break;
            case 2:
                inPlayCards.Clear();
                inPlayCards.AddRange(LevelTwoVisualCards);
                break;
            case 3:
                inPlayCards.Clear();
                inPlayCards.AddRange(LevelThreeVisualCards);
                break;
            default:
                inPlayCards.Clear();
                inPlayCards.AddRange(LevelThreeVisualCards);
                break;
        }
    }
}

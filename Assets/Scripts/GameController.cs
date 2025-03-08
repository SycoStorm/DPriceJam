using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameController : MonoBehaviour
{
    public Data data;
    public LevelManager levelManager;

    [SerializeField] int currentBatchId;
    [SerializeField] int currentMatchId;
    [SerializeField] int currentScore;
    [SerializeField] InGameCard previousCard;
    [SerializeField] InGameCard currentCard;

    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    bool canFlip = true;
    
    private void OnEnable()
    {
       // GameActions.FlipCard += OnFlip;

#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += CheckEditorState;
#endif
    }

    private void OnDisable()
    {
      //  GameActions.FlipCard -= OnFlip;
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= CheckEditorState;
#endif
    }

    private void Update()
    {
        if(canFlip && Input.GetMouseButtonUp(0))
        {
            RayCast();
        }
    }

    public void OnFlip(InGameCard cardFlipped)
    {
        if(data.Turn == 0) //if it's the first flip
        {
            
            currentBatchId = cardFlipped.cardData.GetBatchID();
            currentMatchId = cardFlipped.cardData.GetMatchId();
            previousCard = cardFlipped;
            data.Turn = 1;
        }
        else if(data.Turn == 1)
        {
           if(CheckSameSet(cardFlipped.cardData) == false)
           {
                canFlip = false;
                Invoke("DelayedFlip", 1f);
                
           }
           else
            {
                if(levelManager.CheckIfAllCardsFlipped() == true)
                {
                    scoreText.text = $"All Done! Final score:{currentScore}";
                }
            }
            
            data.Turn = 0;
            ResetMatches();
        }
    }

    public void DelayedFlip()
    {
        previousCard.UnFlipCard();
        currentCard.UnFlipCard();
        previousCard = null;
        canFlip = true;
    }

    public void ResetMatches()
    {
        currentBatchId = 0;
        currentMatchId = 0;
        
    }

    public bool CheckSameSet(Card cardData)
    {
        if(cardData.GetBatchID() == currentBatchId) //is it a match or a match's opposite
        {
            if(cardData.GetMatchId() == currentMatchId) //is it a match or it's opposite
            {
                currentScore += cardData.ReturnMatchPointsGain();
            }
            else
            {
                currentScore += cardData.ReturnOppositesPointsGain();
            }
            scoreText.text = currentScore.ToString();
            return true;
        }
        else
        {
            NoBatchesOrMatchesFound();
            return false;
        }
    }

    public void NoBatchesOrMatchesFound()
    {

    }

    public void RayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.transform.gameObject.TryGetComponent(out InGameCard gameCard) && gameCard.CheckIfFlipped() == false)
            {
                currentCard = gameCard;
                gameCard.OnClickFlip();
                OnFlip(gameCard);
                
            }
        }
    }

    public void CheckEditorState(PlayModeStateChange state)
    {
        if(state == PlayModeStateChange.ExitingPlayMode)
        {
            data.ResetAllLevelsAndScore();
        }
    }

    public void FinilizeData()
    {
        data.OnLevelEnd(currentScore);
        data.ChangeNextLevel();
    }
}

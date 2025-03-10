using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI feedbackText;
    [SerializeField] TextMeshProUGUI scoreOneText;
    [SerializeField] Data data;
    int savedScore;
    int newScore;
    private void Start()
    {
        newScore = data.GetOverallScore();
        feedbackText.text = $"Congrats! You made it to the end! Your Total score is {newScore}. Try playing again to beat your old Score!";

        CheckHighScore();
    }

    public void CheckHighScore()
    {
       savedScore = SaveManager.GetHighScore();

        if(data.GetOverallScore() > savedScore)
        {
            scoreOneText.text = $"New Highscore! \n Old Score: {savedScore} \n New Score: {newScore}";
            SaveData newSave = new SaveData();
            newSave.highScore = newScore;
            SaveManager.SavenewScore(newSave);
        }
        else
        {
            scoreOneText.text = $"Highest Score: {savedScore}";
        }
    }
}

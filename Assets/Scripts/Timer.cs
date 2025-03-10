using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
   [SerializeField] bool isTrackingTime = false;
    private float timer = 0;
    [SerializeField] TextMeshProUGUI timerText; 

    private void Update()
    {
        if(timerText && isTrackingTime)
        {
            timer += Time.deltaTime;
            timerText.text = $"Time: {timer.ToString("#.00")}";
        }
    }

    public void StartTimer()
    {
        isTrackingTime = true;
    }
    public void StopTimer()
    {
        isTrackingTime = false;
        Debug.Log(timer);
    }

    public int GetTimeBonus()
    {
       if(timer < 30)
        {
            timerText.text = $"Time: {timer.ToString("#.00")} \n Congrats you got a time bonus of {5} points";
            return 5;
            
        }
       else if(timer < 60)
        {
            timerText.text = $"Time: {timer.ToString("#.00")} \n Congrats you got a time bonus of {3} points";
            return 3;
        }
       else if(timer < 90)
        {
            timerText.text = $"Time: {timer.ToString("#.00")} \n Congrats you got a time bonus of {1} points";
            return 1;
        }
       else
        {
            return 0;
        }
    }
}

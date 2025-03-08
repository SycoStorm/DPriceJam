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
            timerText.text = timer.ToString("#.00");
        }
    }


}

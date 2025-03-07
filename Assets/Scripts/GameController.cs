using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
     public Data data;
    
    private void OnEnable()
    {
        GameActions.FlipCard += OnFlip;
    }

    private void OnDisable()
    {
        GameActions.FlipCard -= OnFlip;
    }


    public void OnFlip(InGameCard cardFlipped)
    {

    }

    public void CheckSet()
    {

    }
}

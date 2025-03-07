using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCard : MonoBehaviour
{

    public Card cardData;

    bool isFlipped = false;


    public void OnClickFlip()
    {
        GameActions.FlipCard?.Invoke(this);
    }

}

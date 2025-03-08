using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCard : MonoBehaviour
{
    [SerializeField] MeshRenderer rend;
    public Card cardData;

    bool isFlipped = false;


    public void OnClickFlip()
    {
        //GameActions.FlipCard?.Invoke(this);       
        rend.material.color = Color.red;
        isFlipped = true;
    }

    public void UnFlipCard()
    {
        Debug.Log("Unflipping " + gameObject.name);
        rend.material.color = Color.white;
        isFlipped = false;
    }

    public bool CheckIfFlipped()
    {
        return isFlipped;
    }

}

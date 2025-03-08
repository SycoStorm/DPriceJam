using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCard : MonoBehaviour
{
    [SerializeField] MeshRenderer rend;
    [SerializeField] Material glowOnHover;
    [SerializeField] Material defualtCardMat;
    [SerializeField] SpriteRenderer CardSprite;
    [SerializeField] Animator animator;
    public Card cardData;

    bool isFlipped = false;


    public void OnClickFlip()
    {
        rend.material = defualtCardMat;        
       // rend.material.color = Color.red;
        isFlipped = true;
        animator.SetBool("IsFlipped", isFlipped);
    }

    public void UnFlipCard()
    {
        Debug.Log("Unflipping " + gameObject.name);
       // rend.material.color = Color.white;
        isFlipped = false;
        animator.SetBool("IsFlipped", isFlipped);
    }

    public bool CheckIfFlipped()
    {
        return isFlipped;
    }

    private void OnMouseEnter()
    {
        if (isFlipped == false)
        {
            rend.material = glowOnHover;
        }
    }

    public void OnMouseExit()
    {
        if (isFlipped == false)
        {
            rend.material = defualtCardMat;
        }
    }

    public void SetCardSprite(Sprite spriteData)
    {
        CardSprite.sprite = spriteData;
    }

}

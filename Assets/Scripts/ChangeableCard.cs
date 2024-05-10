using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeableCard : MonoBehaviour
{
    public CardVisual card;
    public void ChangeCard()
    {
        this.transform.parent.GetComponent<ChangeCards>().ChangeCard(card);
    }
}

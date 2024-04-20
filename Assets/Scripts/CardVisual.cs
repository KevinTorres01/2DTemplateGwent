using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardVisual : MonoBehaviour
{
    public TextMeshProUGUI points;
    public UnityEngine.UI.Image image;
    public Card Card;

    public void ChangeImage(Card card)
    {
        image.sprite = Resources.Load<Sprite>(card.Name);
        Card = card;
    }
    public void SetPoints(Card card)
    {
        if (card is UnitCard unitCard)
        {
            points.text = unitCard.Score.ToString();
        }
        else points.text = "";
    }

}

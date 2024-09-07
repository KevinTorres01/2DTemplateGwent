using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardVisual : MonoBehaviour
{
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Effect;
    public UnityEngine.UI.Image Base;
    public UnityEngine.UI.Image Character;
    public VerticalLayoutGroup Ranges;
    public GameObject RangePrefab;
    public Card Card;

    public void ChangeImage(Card card)                     //  le asigna la imagen a la carta en el visual
    {
        Card = card;

        if (Card is UnitCard unitCard)
        {
            if (unitCard is SilverCard)
                Base.sprite = Resources.Load<Sprite>("SilverCardBase");
            else Base.sprite = Resources.Load<Sprite>("HeroCardBase");
            //Points.text = unitCard.Score.ToString();
            Name.text =  Card.Name;
            if (unitCard.Possition.Contains("M"))
            {
                var range = Instantiate(RangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                range.transform.SetParent(Ranges.transform);
                range.transform.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Melee");
            }
            if (unitCard.Possition.Contains("R"))
            {
                var range = Instantiate(RangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                range.transform.SetParent(Ranges.transform);
                range.transform.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Ranged");
            }
            if (unitCard.Possition.Contains("S"))
            {
                var range = Instantiate(RangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                range.transform.SetParent(Ranges.transform);
                range.transform.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Siege");
            }
        }
        else
        {
            Base.sprite = Resources.Load<Sprite>("CardBase");
            //Points.text = " ";
            Name.text = Card.Type + " : " + Card.Name;
        }

        Effect.text = Card.Effect;
    }
    public void SetPoints(Card card)                       //   le asigna los puntos a la carta en el visual
    {
        if (card is UnitCard unitCard)
        {
            Points.text = unitCard.Score.ToString();
        }
        else Points.text = " ";
    }

}

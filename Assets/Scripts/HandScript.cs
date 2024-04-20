using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Diagnostics;

public class HandScript : MonoBehaviour
{
    public HorizontalLayoutGroup VisualHand;
    public GameObject CardPrefab;


    void Start()
    {

        if (this.transform.parent.name == "Player1")
        {
            List<Card> hand = GameManager.player1.Playerdeck.DeckList;

            for (int i = 0; i < 10; i++)
            {
                var card = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                card.GetComponent<CardVisual>().ChangeImage(hand[0]);
                card.GetComponent<CardVisual>().SetPoints(hand[0]);
                card.transform.SetParent(VisualHand.transform);
                UnityEngine.Debug.Log(hand[0].Name);
                GameManager.player1.Playerdeck.DeckList.Remove(hand[0]);
            }
        }


        if (this.transform.parent.name == "Player2")
        {
            List<Card> hand1 = GameManager.player2.Playerdeck.DeckList;
            for (int i = 0; i < 10; i++)
            {
                var card = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                card.GetComponent<CardVisual>().ChangeImage(hand1[0]);
                card.GetComponent<CardVisual>().SetPoints(hand1[0]);
                card.transform.SetParent(VisualHand.transform);
                UnityEngine.Debug.Log(hand1[0].Name);
                GameManager.player2.Playerdeck.DeckList.Remove(hand1[0]);
            }
        }

    }
    void Update()
    {
        if (GameManager.player1.IsMyturn == false && this.transform.parent.name == "Player1")
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            return;
        }
        if (GameManager.player2.IsMyturn == false && this.transform.parent.name == "Player2")
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            return;
        }
        if (GameManager.player1.IsMyturn == true && this.transform.parent.name == "Player1")
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        if (GameManager.player2.IsMyturn == true && this.transform.parent.name == "Player2")
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }

    }
}

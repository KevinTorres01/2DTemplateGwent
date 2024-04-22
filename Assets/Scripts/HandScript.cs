using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Diagnostics;
using Unity.VisualScripting;

public class HandScript : MonoBehaviour
{
    public HorizontalLayoutGroup VisualHand;
    public GameObject CardPrefab;


    void Start()
    {

        if (this.transform.parent.name == "Player1")
        {
            List<Card> hand = GameManager.player1.Hand.ListOfCards;

            for (int i = 0; i < 10; i++)
            {
                var card = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                card.GetComponent<CardVisual>().ChangeImage(hand[i]);
                card.GetComponent<CardVisual>().SetPoints(hand[i]);
                card.transform.SetParent(VisualHand.transform);
                UnityEngine.Debug.Log(hand[i].Name);
            }
        }


        if (this.transform.parent.name == "Player2")
        {
            List<Card> hand1 = GameManager.player2.Hand.ListOfCards;
            for (int i = 0; i < 10; i++)
            {
                var card = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                card.GetComponent<CardVisual>().ChangeImage(hand1[i]);
                card.GetComponent<CardVisual>().SetPoints(hand1[i]);
                card.transform.SetParent(VisualHand.transform);
                UnityEngine.Debug.Log(hand1[i].Name);
            }
        }

    }
    public void DrawTwoCards(Player player)
    {

        Hand.DrawTwoCards(player);

        var card = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        card.GetComponent<CardVisual>().ChangeImage(player.Hand.ListOfCards[player.Hand.ListOfCards.Count - 1]);
        card.GetComponent<CardVisual>().SetPoints(player.Hand.ListOfCards[player.Hand.ListOfCards.Count - 1]);
        card.transform.SetParent(VisualHand.transform);

        var card1 = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        card1.GetComponent<CardVisual>().ChangeImage(player.Hand.ListOfCards[player.Hand.ListOfCards.Count - 2]);
        card1.GetComponent<CardVisual>().SetPoints(player.Hand.ListOfCards[player.Hand.ListOfCards.Count - 2]);
        card1.transform.SetParent(VisualHand.transform);
    }
    public void DrawACArd(Player player)
    {
        var card = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        card.GetComponent<CardVisual>().ChangeImage(player.Hand.ListOfCards[player.Hand.ListOfCards.Count - 1]);
        card.GetComponent<CardVisual>().SetPoints(player.Hand.ListOfCards[player.Hand.ListOfCards.Count - 1]);
        card.transform.SetParent(VisualHand.transform);
        UnityEngine.Debug.Log("Se robo la carta en el fronten");
        for (int i = 0; i < player.Hand.ListOfCards.Count; i++)
        {
            UnityEngine.Debug.Log(player.Hand.ListOfCards[i].Name);
        }
        UnityEngine.Debug.Log("En el mazo hay" + player.Playerdeck.DeckList.Count + "cartas");
        UnityEngine.Debug.Log("En la mano hay" + player.Hand.ListOfCards.Count + "cartas");
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

using System.Security.Cryptography.X509Certificates;

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class Hand
{
    public List<Card> ListOfCards;
    public int AmountOfCards;

    public Hand(List<Card> deck)
    {
        ListOfCards = new List<Card>();
        AmountOfCards = 0;
        while (AmountOfCards < 10)
        {
            ListOfCards.Add(deck[0]);
            deck.Remove(deck[0]);
            AmountOfCards++;
        }
    }
    public static void DrawTwoCards(Player player1)
    {
        for (int i = 0; i < 2; i++)
        {
            Debug.Log( "Este es el nombre de la cata q da error" + player1.Playerdeck.DeckList[0].Name);
            player1.Hand.ListOfCards.Add(player1.Playerdeck.DeckList[0]);
            player1.Playerdeck.DeckList.Remove(player1.Playerdeck.DeckList[0]);
            // player2.Hand.ListOfCards.Add(player2.Playerdeck.DeckList[0]);
            // player2.Playerdeck.DeckList.Remove(player2.Playerdeck.DeckList[0]);
        }
    }
    


}
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DeckCreator
{
    public static Dictionary<string, Deck> decks => GetDecks();
    static Dictionary<string, Deck> GetDecks()
    {
        Dictionary<string, Deck> deck = new();
        foreach (var item in CardCreator.Liders)
        {
            Deck Deck = new Deck(item.Faction);
            if (Deck.DeckList.Count >= 25 && !deck.ContainsKey(item.Faction))
            {
                deck.Add(item.Faction, Deck);
            }
        }
        return deck;
    }
}


public class Deck
{
    public Lider Lider;
    public List<Card> DeckList;

    public Deck(string Faction)
    {
        Lider = GetLider(CardCreator.CreateDeck(Faction));
        DeckList = new List<Card>();
        foreach (var card in CardCreator.CreateDeck(Faction))
        {
            if (card.Type != "Lider")
            {
                DeckList.Add(card);
            }
        }
        DeckList = Swap(DeckList);
    }
    public static List<Card> Swap(List<Card> cards)       //barajar el deck
    {
        int i = 0;
        System.Random random = new System.Random();
        System.Random random1 = new System.Random();
        Card temp;
        while (i < cards.Count)
        {
            int aleatory = random.Next(cards.Count - 1);
            int aleatory1 = random1.Next(cards.Count - 1);
            temp = cards[aleatory];
            cards[aleatory] = cards[aleatory1];
            cards[aleatory1] = temp;
            i++;

        }
        return cards;
    }
    static Lider GetLider(List<Card> ListaDeCartas)
    {

        Lider lider1 = new Lider("default", "", "default");
        foreach (var card in ListaDeCartas)
        {
            if (card.Type == "Lider")
            {
                lider1 = new Lider(card.Name, card.Effect, card.Faction);
            }
        }
        return lider1;
    }
}

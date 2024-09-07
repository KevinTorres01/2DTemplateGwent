using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Context
{
    public List<Card> Hand => HandOfPlayer(TrigerPlayer);
    public List<UnitCard>[] Board = new List<UnitCard>[]{GameManager.player1.boardPlayer.UnitCards[0]
                                                        ,GameManager.player1.boardPlayer.UnitCards[1]
                                                        ,GameManager.player1.boardPlayer.UnitCards[2]
                                                        ,GameManager.player2.boardPlayer.UnitCards[0]
                                                        ,GameManager.player2.boardPlayer.UnitCards[1]
                                                        ,GameManager.player2.boardPlayer.UnitCards[2] };
    public int TrigerPlayer => GameManager.player1.IsMyturn ? 0 : 1;
    public List<Card> Graveyard => GraveyardOfPlayer(TrigerPlayer);
    public List<Card> Deck => DeckOfPlayer(TrigerPlayer);
    public List<Card> Field => FieldOfPlayer(TrigerPlayer);

    public List<Card> HandOfPlayer(int Id)
    {
        return Id == 0 ? GameManager.player1.Hand.ListOfCards : GameManager.player2.Hand.ListOfCards;
    }
    public List<Card> GraveyardOfPlayer(int ID)
    {
        return ID == 0 ? GameManager.player1.Graveyard : GameManager.player2.Graveyard;
    }
    public List<Card> DeckOfPlayer(int ID)
    {
        return ID == 0 ? GameManager.player1.Graveyard : GameManager.player2.Graveyard;
    }
    public List<Card> FieldOfPlayer(int ID)
    {
        List<Card> cards = new List<Card>();
        if (ID == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                foreach (var item in GameManager.player1.boardPlayer.UnitCards[i])
                {
                    cards.Add(item);
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                foreach (var item in GameManager.player2.boardPlayer.UnitCards[i])
                {
                    cards.Add(item);
                }
            }
        }
        return cards;
    }
}

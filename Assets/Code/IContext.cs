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
    public Player TrigerPlayer => GameManager.player1.IsMyturn ? GameManager.player1 : GameManager.player2;
    public List<Card> Graveyard => GraveyardOfPlayer(TrigerPlayer);
    public List<Card> Deck => DeckOfPlayer(TrigerPlayer);
    public List<Card> Field => FieldOfPlayer(TrigerPlayer);

    public List<Card> HandOfPlayer(Player player)
    {
        return player.Hand.ListOfCards;
    }
    public List<Card> GraveyardOfPlayer(Player player)
    {
        return player.Graveyard;
    }
    public List<Card> DeckOfPlayer(Player player)
    { return player.Playerdeck.DeckList; }
    public List<Card> FieldOfPlayer(Player player)
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < 3; i++)
        {
            foreach (var item in player.boardPlayer.UnitCards[i])
            {
                cards.Add(item);
            }
        }
        return cards;
    }
}

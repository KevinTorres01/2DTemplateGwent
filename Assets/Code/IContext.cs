using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    public List<UnitCard>[] Field => FieldOfPlayer(TrigerPlayer);

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
        Debug.Log(GameManager.player1.Playerdeck.DeckList.Count+" Count player 1");
        Debug.Log(GameManager.player2.Playerdeck.DeckList.Count+" count player 2");
        return ID == 0 ? GameManager.player1.Playerdeck.DeckList : GameManager.player2.Playerdeck.DeckList;
    }
    public List<UnitCard>[] FieldOfPlayer(int ID)
    {
        return ID == 0 ? GameManager.player1.boardPlayer.UnitCards : GameManager.player2.boardPlayer.UnitCards;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static string Player1Name;
    public static string Player2Name;
    public static string Player1Faction;
    public static string Player2Faction;
    public static Player Player1;
    public static Player Player2;
    public static GameData gameData;
    void Awake()                           // guardo los datos de la escena de poner el nombre 
    {
        if (gameData == null)
        {
            gameData = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (gameData != this)
            Destroy(gameObject);
    }

    public void FillPlayer1Name(string name)
    {
        Player1Name = name;
    }
    public void FillPlayer2Name(string name)
    {
        Player2Name = name;
    }
    public void FillPlayer1Faction(string faction)
    {
        Player1Faction = faction;
    }
    public void FillPlayer2Faction(string faction)
    {
        Player2Faction = faction;
    }
    public void CreatePlayers()
    {
        CardCreator.CreateCards();
        Deck Deck1 = new Deck(Player1Faction);
        Deck Deck2 = new Deck(Player2Faction);
        Player1 = new Player(Player1Name, new Board(), Deck1, new Hand(Deck1.DeckList));
        Player2 = new Player(Player2Name, new Board(), Deck2, new Hand(Deck2.DeckList));
    }
    public void ChangeCard(Player player, Card card)
    {
        player.Playerdeck.DeckList.Add(card);
        player.Hand.ListOfCards.Remove(card);
        player.Hand.ListOfCards.Add(player.Playerdeck.DeckList[0]);
        player.Playerdeck.DeckList.Remove(player.Playerdeck.DeckList[0]);
    }

    public static void ResetData()
    {
        Player1Name = null;
        Player2Name = null;
        Player1Faction = null;
        Player2Faction = null;
        GameData.Player1 = null;
        GameData.Player2 = null;
    }

}

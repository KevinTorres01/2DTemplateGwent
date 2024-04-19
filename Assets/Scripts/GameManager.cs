using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static Player player1;

    public static Player player2;
    void Awake()
    {
        List<Card> list1 = new List<Card>();
        List<Card> list2 = new List<Card>();
        for (int i = 0; i < CardCreator.CreateCards().Count; i++)
        {
            list1.Add(CardCreator.CreateCards()[i]);
            list2.Add(CardCreator.CreateCards()[i]);
        }


        Board board1 = new Board();
        Deck deck1 = new Deck(list1);
        Hand hand1 = new Hand(deck1.DeckList);
        Board board2 = new Board();
        Deck deck2 = new Deck(list2);
        Hand hand2 = new Hand(deck2.DeckList);
        player1 = new Player("Kevin", board1, deck1, hand1);
        player2 = new Player("Lianny", board2, deck2, hand2);
        WhoStart(player1, player2);
    }
    public static void SetVictory(Player player1, Player player2)
    {
        if (player1.IsMyturn == false && player2.IsMyturn == false && player1.boardPlayer.score > player2.boardPlayer.score)
        {
            Victory(player1);
            // round.winner = player1;
        }
        if (player1.IsMyturn == false && player2.IsMyturn == false && player2.boardPlayer.score > player1.boardPlayer.score)
        {
            Victory(player2);
            //  round.winner = player2;
        }
        if (player1.IsMyturn == false && player2.IsMyturn == false && player2.boardPlayer.score == player1.boardPlayer.score)
        {
            Victory(player1);
            Victory(player2);
            // System.Random random = new System.Random();
            // int a = random.Next(0, 1);
            // if (a == 1)
            // {
            // //    round.winner = player2;
            // }
            // else
            // {
            //   //  round.winner = player1;
            // }
        }
    }
    static void Victory(Player player)
    {
        player.Victories++;
    }
    // Update is called once per frame
    static void WhoStart(Player player1, Player player2)
    {
        System.Random random = new System.Random();
        int a = random.Next(0, 3);
        if (a % 2 == 1)
        {
            player2.IsMyturn = true;
        }
        else
        {
            player1.IsMyturn = true;
        }

    }
    public static void PassTurn()
    {
        if (player1.IsMyturn)
        {
            player1.Pased = true;
            player1.IsMyturn = false;
            if (player2.Pased == false)
            {
                player2.IsMyturn = true;
            }
            else
            {
                SetVictory(player1, player2);
            }
        }
        else
        {
            player2.Pased = false;
            player2.IsMyturn = false;
            if (player1.Pased == false)
            {
                player1.IsMyturn = true;
            }
            else
            {
                SetVictory(player1, player2);
            }
        }



    }
    static void PassedTurn()
    {
        if (player1.Pased)
        {
            
        }
    }
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Image FirstWin1;
    public UnityEngine.UI.Image FirstWin2;
    public UnityEngine.UI.Image SecondWin1;
    public UnityEngine.UI.Image SecondWin2;
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
    void Start()
    {
        FirstWin1.gameObject.SetActive(false);
        SecondWin1.gameObject.SetActive(false);
        FirstWin2.gameObject.SetActive(false);
        SecondWin2.gameObject.SetActive(false);
    }
    public static void SetVictory(Player player1, Player player2)
    {
        if (player1.IsMyturn == false && player2.IsMyturn == false && player1.boardPlayer.score > player2.boardPlayer.score)
        {
            Victory(player1);
            player1.IsMyturn = true;
            NewRound();

        }
        if (player1.IsMyturn == false && player2.IsMyturn == false && player2.boardPlayer.score > player1.boardPlayer.score)
        {
            Victory(player2);
            player2.IsMyturn = true;
            NewRound();
        }
        if (player1.IsMyturn == false && player2.IsMyturn == false && player2.boardPlayer.score == player1.boardPlayer.score)
        {
            Victory(player1);
            Victory(player2);
            WhoStart(player1, player2);
            NewRound();
        }
    }
    static void NewRound()
    {
        player1.Pased = false;
        player2.Pased = false;
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
            Debug.Log("se presiono el boton 1");
            player1.Pased = true;
            player1.IsMyturn = false;
            if (player2.Pased == false)
            {
                player2.IsMyturn = true;
                Debug.Log("turno del jugador 2");
                Debug.Log("El passsed del jugador 1 esta en false");
            }
            else
            {
                SetVictory(player1, player2);
                Debug.Log("la ronda ha terminado");
                Debug.Log("El passsed del jugador 1 esta en true");
            }
        }
        else
        {
            Debug.Log("se presiono el boton 2");
            player2.Pased = true;
            player2.IsMyturn = false;
            if (player1.Pased == false)
            {
                player1.IsMyturn = true;
                Debug.Log("turno del jugador 1");
            }
            else
            {
                SetVictory(player1, player2);
                Debug.Log("la ronda ha terminado");
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
        if (player1.Victories == 1)
        {
            FirstWin1.gameObject.SetActive(true);
        }
        if (player2.Victories == 1)
        {
            FirstWin2.gameObject.SetActive(true);
        }
        if (player1.Victories == 2)
        {
            SecondWin1.gameObject.SetActive(true);
        }
        if (player2.Victories == 2)
        {
            SecondWin2.gameObject.SetActive(true);
        }
    }
}

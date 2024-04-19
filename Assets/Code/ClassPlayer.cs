using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class Player
{
    public string Name { get; private set; }
    public Board boardPlayer { get; set; }
    public Deck Playerdeck { get; set; }
    public Hand Hand { get; set; }
    public bool IsMyturn { get; set; }
    public int Victories;
    public bool Pased;

    public Player(string name, Board board, Deck deck, Hand hand)
    {
        Name = name;
        boardPlayer = board;
        Playerdeck = deck;
        Hand = hand;
        IsMyturn = false;
        Victories = 0;
        Pased = false;
    }
    public static void EndTurn(Player player)
    {
        player.IsMyturn = false;
    }
    public static void StartTurn(Player player)
    {
        player.IsMyturn = true;
    }
    public static void Pas(Player player)
    {
        player.Pased = true;
    }
   
   
}
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
    public List<Card> Graveyard;

    public Player(string name, Board board, Deck deck, Hand hand)
    {
        Name = name;
        boardPlayer = board;
        Playerdeck = deck;
        Hand = hand;
        IsMyturn = false;
        Victories = 0;
        Pased = false;
        Graveyard = new List<Card>();
    }
}
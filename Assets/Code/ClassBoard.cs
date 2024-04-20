using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class Board
{
    public static Weather[] BothPlayersWeather = new Weather[3];
    public int score;
    public int rowMPoints;
    public int rowRPoints;
    public int rowSPoints;
    public List<UnitCard>[] UnitCards = new List<UnitCard>[3];
    public BonusCard[] bonus;


    public Board()
    {
        score = 0;
        List<UnitCard> M = new List<UnitCard>();
        List<UnitCard> R = new List<UnitCard>();
        List<UnitCard> S = new List<UnitCard>();
        UnitCards[0] = M;
        UnitCards[1] = R;
        UnitCards[2] = S;
        bonus = new BonusCard[3];
        rowMPoints = 0;
        rowRPoints = 0;
        rowSPoints = 0;
    }
    public static void UpdatePoints(Board board)
    {
        board.rowMPoints = 0;
        board.rowRPoints = 0;
        board.rowSPoints = 0;
        board.score = 0;
        foreach (var item in board.UnitCards[0])
        {
            board.rowMPoints += item.Score;
        }
        foreach (var item in board.UnitCards[1])
        {
            board.rowRPoints += item.Score;
        }
        foreach (var item in board.UnitCards[2])
        {
            board.rowSPoints += item.Score;
        }
        board.score = board.rowMPoints + board.rowRPoints + board.rowSPoints;

    }
    public static UnitCard GetPowerfulCard(List<UnitCard>[] unitCards)
    {
        UnitCard result = new UnitCard("default", "", "default", "", 0);
        for (int i = 0; i < unitCards.Length; i++)
        {
            foreach (var item in unitCards[i])
            {
                if (result.Score == 0)                              //result = a la primera carta q me encuentre en la lista , luego cada vez q me encuentre una carta comparo los score
                {
                    result = item;
                }
                else
                {
                    if (item.Score > result.Score)
                    {
                        result = item;
                    }
                }
            }
        }
        return result;

    }

    public static UnitCard GetWeakCard(List<UnitCard>[] unitCards)
    {
        UnitCard result = new UnitCard("default", "", "default", "", int.MaxValue);
        for (int i = 0; i < unitCards.Length; i++)
        {
            foreach (var item in unitCards[i])
            {
                if (result.Score == int.MaxValue)                              //res = a la primera carta q me encuentre en la lista , luego cada vez q me encuentre una carta comparo los score
                {
                    result = item;
                }
                else
                {
                    if (item.Score < result.Score)
                    {
                        result = item;
                    }
                }
            }
        }
        return result;
    }
    public static void CleanBoard(Player player, Player player1)
    {
        Weather[] CleanWeathers = null;
        CleanWeathers = new Weather[3];
        BonusCard[] CleanBonus1 = null;
        CleanBonus1 = new BonusCard[3];
        BonusCard[] CleanBonus2 = new BonusCard[3];
        List<UnitCard>[] CleanBoard1 = null;
        CleanBoard1 = new List<UnitCard>[3];
        List<UnitCard>[] CleanBoard2 = null;
        CleanBoard2 = new List<UnitCard>[3];
        CleanBoard1[0] = new List<UnitCard>();
        CleanBoard2[0] = new List<UnitCard>();
        CleanBoard1[1] = new List<UnitCard>();
        CleanBoard2[1] = new List<UnitCard>();
        CleanBoard1[2] = new List<UnitCard>();
        CleanBoard2[2] = new List<UnitCard>();

        Board.BothPlayersWeather = CleanWeathers;

        player1.boardPlayer.UnitCards = CleanBoard1;
        player1.boardPlayer.bonus = CleanBonus1;

        player.boardPlayer.UnitCards = CleanBoard2;
        player.boardPlayer.bonus = CleanBonus2;
        Board.UpdatePoints(player1.boardPlayer);
        Board.UpdatePoints(player.boardPlayer);


    }
}
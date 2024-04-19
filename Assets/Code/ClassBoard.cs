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
    public static void UpdatePointsM(Board board)
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
    public static void Actpoints(Board board)
    {
        for (int i = 0; i < board.UnitCards.Length; i++)
        {
            foreach (var item in board.UnitCards[i])
            {
                board.score += item.Score;
            }
        }
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
}
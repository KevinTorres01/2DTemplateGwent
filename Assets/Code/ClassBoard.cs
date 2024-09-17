using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class Board
{
    public static Weather[] BothPlayersWeather = new Weather[3];                                     //  Array de Weathers, donde los jugadores pondran un clima
    public int score;                                                                                //  Entero score para conocer los puntos totales del jugdor
    public int rowMPoints;                                                                           //  Entero para conocer los puntos de la fila M del jugador
    public int rowRPoints;                                                                           //  Entero para conocer los puntos de la fila R del jugador
    public int rowSPoints;                                                                           //  Entero para conocer los puntos de la fila S del jugador
    public List<UnitCard>[] UnitCards = new List<UnitCard>[3];                                       //  Array de listas para las filas de las cartas unidad
    public BonusCard[] bonus;                                                                        //  Array para las cartas clima del jugador


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
    public static void UpdatePoints(Board board)                //Metodo para actualizar los puntos de las filas y del tablero 
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
    public static UnitCard GetPowerfulCard(List<UnitCard>[] unitCards)            //Metodo para obtener la carta mas poderosa del tablero (catas de unidad)
    {
        UnitCard result = new UnitCard("default", "", "default", "", 0);
        for (int i = 0; i < unitCards.Length; i++)
        {
            foreach (var item in unitCards[i])
            {
                if (result.Score == 0 && item is not GoldenCard)                              //result = a la primera carta q me encuentre en la lista que no sea de oro , luego cada vez q me encuentre una carta comparo los score
                {
                    result = item;
                }
                else
                {
                    if (item.Score > result.Score && item is not GoldenCard)
                    {
                        result = item;
                    }
                }
            }
        }
        return result;

    }

    public static UnitCard GetWeakCard(List<UnitCard>[] unitCards)                // Metodo para obtener la carta mas debil del tablero
    {
        UnitCard result = new UnitCard("default", "", "default", "", int.MaxValue);
        for (int i = 0; i < unitCards.Length; i++)
        {
            foreach (var item in unitCards[i])
            {
                if (result.Score == int.MaxValue && item is not GoldenCard)                              //res = a la primera carta de plata q me encuentre en la lista , luego cada vez q me encuentre una carta comparo los score
                {
                    result = item;
                }
                else
                {
                    if (item.Score < result.Score && item is not GoldenCard)
                    {
                        result = item;
                    }
                }
            }
        }
        return result;
    }
    public static void ActPointsInRow(Board boardPlayer1, Board boardPlayer2, int row)
    {
        if (Board.BothPlayersWeather[row] != null && Board.BothPlayersWeather[row].Effect != "")
        {
            for (int i = 0; i < boardPlayer1.UnitCards[row].Count; i++)
            {
                if (boardPlayer1.UnitCards[row][i] is UnitCard unitCard1)
                {
                    unitCard1.Score = 1;
                }
            }
            for (int i = 0; i < boardPlayer2.UnitCards[row].Count; i++)
            {
                if (boardPlayer2.UnitCards[row][i] is UnitCard unitCard1)
                {
                    unitCard1.Score = 1;
                }
            }
        }
        if (boardPlayer1.bonus[row] != null && boardPlayer1.bonus[row].Effect != "")
        {
            foreach (var item in boardPlayer1.UnitCards[row])
            {
                if (item is SilverCard && ((item.Score == 1) || item.Score == item.PowerPoints))
                {
                    item.Score += 3;
                }
            }
        }
        if (boardPlayer2.bonus[row] != null && boardPlayer2.bonus[row].Effect != "")
        {
            foreach (var item in boardPlayer2.UnitCards[row])
            {
                if (item is SilverCard && ((item.Score == 1) || item.Score == item.PowerPoints))
                {
                    item.Score += 3;
                }
            }
        }
    }
    public static void CleanBoard(Player player, Player player1)                   // Metodo para limpiar el tablero 
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
        for (int i = 0; i < 3; i++)
        {
            foreach (var item in player.boardPlayer.UnitCards[i])
            {
                player.Graveyard.Add(item);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            foreach (var item in player1.boardPlayer.UnitCards[i])
            {
                player1.Graveyard.Add(item);
            }
        }

        player1.boardPlayer.UnitCards = CleanBoard1;
        player1.boardPlayer.bonus = CleanBonus1;

        player.boardPlayer.UnitCards = CleanBoard2;
        player.boardPlayer.bonus = CleanBonus2;
        Board.UpdatePoints(player1.boardPlayer);
        Board.UpdatePoints(player.boardPlayer);
    }
}
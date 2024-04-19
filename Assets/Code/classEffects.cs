using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public abstract class Effects
{
    public static Dictionary<string, Effects> GiveEffect { get; set; } = Fill();
    public Effects()
    {

    }
    static Dictionary<string, Effects> Fill()
    {
        Dictionary<string, Effects> ef = new Dictionary<string, Effects>();
        ef.Add("Multiply", new Multiply());
        ef.Add("DeletRivalWeek", new DeletRivalWeak());
        ef.Add("DeletPowerful", new DeletPowerful());
        ef.Add("Draw", new Draw());
        ef.Add("Clean", new Clean());
        ef.Add("BonusR", new BonificationR());
        ef.Add("BonusS", new BonificationS());
        ef.Add("BonusM", new BonificationM());
        ef.Add("Average", new Averages());
        ef.Add("WeatherR", new WeatherEffect_R());
        ef.Add("WeatherM", new WeatherEffect_M());
        ef.Add("WeatherS", new WeatherEffect_S());
        ef.Add("CleanWeather",new CleanWeather());
        return ef;
    }

    public abstract void ActivateEffect(Player player, Player player1, Card unitCard);
}
class Multiply : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        Increase(player, player1, unitCard);
    }
    public void Increase(Player player, Player player1, Card unitCard)    //multiplicar los puntos de una carta por n
    {
        int count = 0;
        string temp = unitCard.Name;

        for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player.boardPlayer.UnitCards[i])
            {
                if (item.Name == temp)
                {
                    count++;
                }
            }
        }

        for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player1.boardPlayer.UnitCards[i])
            {
                if (item.Name == temp)
                {
                    count++;
                }
            }
        }

        for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player.boardPlayer.UnitCards[i])
            {
                if (item.Name == temp)
                {
                    item.Score = item.Score * count;
                }
            }
        }

        for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player1.boardPlayer.UnitCards[i])
            {
                if (item.Name == temp)
                {
                    item.Score = item.Score * count;
                }
            }
        }
    }
}
//-----------------------------------------------------------------------------------------------------------------
class DeletRivalWeak : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        DeletRivalWeakCard(player, player1, unitCard);
    }
    public void DeletRivalWeakCard(Player player, Player player1, Card unitCard)            //eliminar la carta mas debil del rival
    {
        if (player.IsMyturn)
        {
            Card weak = Board.GetWeakCard(player1.boardPlayer.UnitCards);
            string temp = weak.Name;
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player1.boardPlayer.UnitCards[i])
                {
                    if (item.Name == temp)
                    {
                        player1.boardPlayer.UnitCards[i].Remove(item);
                        return;
                    }
                }
            }
        }
        else DeletRivalWeakCard(player1, player, unitCard);

    }
}

//---------------------------------------------------------------------------------------------------------------------------------
class DeletPowerful : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        DeletPowerfulCard(player, player1, unitCard);
    }
    public void DeletPowerfulCard(Player player, Player player1, Card unitCard)
    {
        UnitCard PowerfulP = Board.GetPowerfulCard(player.boardPlayer.UnitCards);
        UnitCard PowerfulP1 = Board.GetPowerfulCard(player1.boardPlayer.UnitCards);
        int count = 0;
        if (player.IsMyturn && PowerfulP.Score == PowerfulP1.Score)
        {
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player1.boardPlayer.UnitCards[i])
                {
                    if (item == PowerfulP)
                    {
                        player1.boardPlayer.UnitCards[i].Remove(item);
                        count++;
                        break;
                    }
                }
                if (count != 0) break;
            }

        }
        if (player1.IsMyturn && PowerfulP.Score == PowerfulP1.Score)
        {
            for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player.boardPlayer.UnitCards[i])
                {
                    if (item == PowerfulP)
                    {
                        player.boardPlayer.UnitCards[i].Remove(item);
                        count++;
                        break;
                    }
                }
                if (count != 0) break;
            }

        }
        if (PowerfulP.Score != PowerfulP1.Score)
        {
            UnitCard p = PowerfulP.Score > PowerfulP1.Score ? PowerfulP : PowerfulP1;
            for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player.boardPlayer.UnitCards[i])
                {
                    if (item == p)
                    {
                        player.boardPlayer.UnitCards[i].Remove(item);
                        return;
                    }
                }
            }
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player1.boardPlayer.UnitCards[i])
                {
                    if (item == p)
                    {
                        player1.boardPlayer.UnitCards[i].Remove(item);
                        return;
                    }
                }
            }
        }
    }
}
//----------------------------------------------------------------------------------------------------------

class Draw : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        DrawACArd(player, player1, unitCard);
    }
    public void DrawACArd(Player player, Player player1, Card unitCard)
    {
        if (player.IsMyturn)
        {
            player.Hand.ListOfCards.Add(player.Playerdeck.DeckList[0]);
            player.Playerdeck.DeckList.Remove(player.Playerdeck.DeckList[0]);
        }
        else DrawACArd(player1, player, unitCard);
    }
}
//----------------------------------------------------------------------------------------------------------
class Clean : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        CleanRow(player, player1, unitCard);
    }
    public void CleanRow(Player player, Player player1, Card unitCard)                    //  Guardo las longitudes de las filas en un array, tomo la minima
    {                                                                             // y si es turno de un jugador entonces busco la fila del otro jugador 
        int[] array = new int[6];                                                 // con la minima longitud q tome, si no la encuentro entonces busco entre mis filas. 
        array[0] = player.boardPlayer.UnitCards[0].Count;                         // Si no es mi turno hago el mismo pocedimiento pero desde la perspectiva del otro jugador
        array[1] = player.boardPlayer.UnitCards[1].Count;
        array[2] = player.boardPlayer.UnitCards[2].Count;
        array[3] = player1.boardPlayer.UnitCards[0].Count;
        array[4] = player1.boardPlayer.UnitCards[1].Count;
        array[5] = player1.boardPlayer.UnitCards[2].Count;
        Array.Sort(array);
        int value = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                value = array[i];
                break;
            }
        }

        List<UnitCard> units = new List<UnitCard>();
        int count = 0;

        if (player.IsMyturn)
        {
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                if (player1.boardPlayer.UnitCards[i].Count == value)
                {
                    player1.boardPlayer.UnitCards[i] = units;
                    count++;
                    break;
                }
            }

            if (count == 0)
            {
                for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
                {
                    if (player.boardPlayer.UnitCards[i].Count == value)
                    {
                        player.boardPlayer.UnitCards[i] = units;
                        count++;
                        break;
                    }
                }
            }
        }
        else
        {
            CleanRow(player1, player, unitCard);
        }

    }
}
//--------------------------------------------------------------------------------------------------------
class BonificationR : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        Bonus(player, player1, unitCard);
    }
    public void Bonus(Player player, Player player1, Card card)
    {
        if (player.IsMyturn)
        {
            foreach (var item in player.boardPlayer.UnitCards[1])
            {
                if (item.Type == "Silver")
                {
                    item.Score += 3;
                }
            }
        }
        else Bonus(player1, player, card);
    }

}
class BonificationM : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        Bonus(player, player1, unitCard);
    }
    public void Bonus(Player player, Player player1, Card card)
    {
        if (player.IsMyturn)
        {
            foreach (var item in player.boardPlayer.UnitCards[0])
            {
                if (item.Type == "Silver")
                {
                    item.Score += 3;
                }
            }
        }
        else Bonus(player1, player, card);
    }

}
class BonificationS : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        Bonus(player, player1, unitCard);
    }
    public void Bonus(Player player, Player player1, Card card)
    {
        if (player.IsMyturn)
        {
            foreach (var item in player.boardPlayer.UnitCards[2])
            {
                if (item.Type == "Silver")
                {
                    item.Score += 3;
                }
            }
        }
        else Bonus(player1, player, card);
    }

}
class Empty : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        NoEffect(player, player1, unitCard);
    }
    public void NoEffect(Player player, Player player1, Card card)
    {

    }
}
//------------------------------------------------------------------------------------------------------
class Averages : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        Average(player, player1, unitCard);
    }
    static void Average(Player player, Player player1, Card unitCard)
    {
        int prom = 0;
        int nomberOfcards = 0;
        for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player.boardPlayer.UnitCards[i])
            {
                prom = item.Score;
                nomberOfcards++;
            }
        }
        for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player1.boardPlayer.UnitCards[i])
            {
                prom = item.Score;
                nomberOfcards++;
            }
        }
        prom = prom / nomberOfcards;
        for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player.boardPlayer.UnitCards[i])
            {
                if (item.Type == "Silver")
                {
                    item.Score = prom;
                }
            }
        }
        for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player1.boardPlayer.UnitCards[i])
            {
                if (item.Type == "Silver")
                {
                    item.Score = prom;
                }
            }
        }
    }
}
//--------------------------------------------------------------------------------------------------------
class WeatherEffect_R : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        WeatherR(player, player1, unitCard);
    }
    static void WeatherR(Player player, Player player1, Card unitCard)
    {
        foreach (var item in player.boardPlayer.UnitCards[1])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
            }
        }
        foreach (var item in player1.boardPlayer.UnitCards[1])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
            }
        }
    }
}
//---------------------------------------------------------------------------------------------------------
class WeatherEffect_M : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        WeatherR(player, player1, unitCard);
    }
    static void WeatherR(Player player, Player player1, Card unitCard)
    {
        foreach (var item in player.boardPlayer.UnitCards[0])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
            }
        }
        foreach (var item in player1.boardPlayer.UnitCards[0])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
            }
        }
    }
}
//-------------------------------------------------------------------------------------------------------
class WeatherEffect_S : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        WeatherR(player, player1, unitCard);
    }
    static void WeatherR(Player player, Player player1, Card unitCard)
    {
        foreach (var item in player.boardPlayer.UnitCards[2])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
            }
        }
        foreach (var item in player1.boardPlayer.UnitCards[2])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
            }
        }
    }
}
class CleanWeather : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        CleanW(player, player1, unitCard);
    }
    static void CleanW(Player player, Player player1, Card unitCard)
    {
    Weather[] wheathers = new Weather[3];
    Board.BothPlayersWeather = wheathers;
    }
}

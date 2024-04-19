using UnityEngine;
using System.Collections;
using System;

public abstract class Card
{
    public string Name { get; private set; }
    public virtual string Type { get; protected set; } = "";
    public virtual string Faction { get; protected set; } = "";
    public string Effect;
    public Card(string name, string ef)
    {
        Name = name;
        Effect = ef;
    }
    public void TakeEffect(Player player, Player player1, Card card)
    {
        Effects Do = Effects.GiveEffect[card.Effect];
        Do.ActivateEffect(player, player1, card);
    }
}
//----------------------------------------------------------------------------------------------
public class UnitCard : Card
{
    public string Possition { get; private set; }
    public virtual int Score { get; set; }
    public virtual int PowerPoints { get; private set; }

    public virtual int Appearances { get; protected set; }


    public UnitCard(string name, string ef, string faction, string row, int points) : base(name, ef)
    {
        Possition = row;
        Faction = faction;
        Score = points;
        PowerPoints = points;
    }
    public static void ChangeAppearances(UnitCard unitCard)
    {
        unitCard.Appearances++;
    }
}
//-----------------------------------------------------------------------------------------------
public class SilverCard : UnitCard
{


    public SilverCard(string name, string ef, string faction, string row, int points) : base(name, ef, faction, row, points)
    {
        Appearances = 3;
        Type = "Silver";
    }

}
//--------------------------------------------------------------------------------------------------
public class GoldenCard : UnitCard
{
    public GoldenCard(string name, string ef, string faction, string row, int points) : base(name, ef, faction, row, points)
    {
        Appearances = 1;
        Type = "Golden";

    }
}
//--------------------------------------------------------------------------------------------------
public class DecoyCard : UnitCard
{
    public DecoyCard(string name, string ef, string faction, string row, int points) : base(name, ef, faction, row, points)
    {
        Appearances = 1;
        Score = 0;
        Type = "Decoy";


    }
}
//-----------------------------------------------------------------------------------------------
public class SpecialCard : Card
{

    public SpecialCard(string name, string ef) : base(name, ef)
    {
        Faction = "Neutral";
    }
}
//-----------------------------------------------------------------------------------------------
public class Weather : SpecialCard
{

    public Weather(string name, string ef) : base(name, ef)
    {
        Type = "Weather";
    }

}
//----------------------------------------------------------------------------------------------
public class BonusCard : SpecialCard
{

    public BonusCard(string name, string ef) : base(name, ef)
    {
        Type = "Bonus";
    }
}
//------------------------------------------------------------------------------------------------
public class Clearance : SpecialCard
{
    public Clearance(string name, string ef) : base(name, ef)
    {
        Type = "Despeje";
    }
}
//------------------------------------------------------------------------------------------------
public class Lider : Card
{
    public Lider(string name, string ef, string faction) : base(name, ef)
    {
        Type = "Lider";
        Faction = faction;
    }
}

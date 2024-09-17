using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Card
{
    public string Name { get; private set; }
    public virtual string Type { get; protected set; } = "";
    public virtual string Faction { get; protected set; } = "";
    public string Effect;
    public string row;
    public List<OnActivationObject> onActivations;
    public Card(string name, string ef, string row)
    {
        this.row = row;
        Name = name;
        Effect = ef;
    }
    public Card(string name, string ef, string row, List<OnActivationObject> onActivationObjects)
    {
        this.row = row;
        Name = name;
        Effect = ef;
        onActivations = onActivationObjects;
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
    public List<OnActivationObject> OnActivations = new List<OnActivationObject>();


    public UnitCard(string name, string ef, string faction, string row, int points) : base(name, ef, row)
    {
        Possition = row;
        Faction = faction;
        Score = points;
        PowerPoints = points;
    }
    public UnitCard(string name, string ef, string faction, string row, int points, List<OnActivationObject> onActivationObjects) : base(name, ef, row,onActivationObjects)
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
    public SilverCard(string name, string ef, string faction, string row, int points, List<OnActivationObject> onActivationObjects) : base(name, ef, faction, row, points, onActivationObjects)
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
    public GoldenCard(string name, string ef, string faction, string row, int points, List<OnActivationObject> onact) : base(name, ef, faction, row, points, onact)
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
    public DecoyCard(string name, string ef, string faction, string row, int points, List<OnActivationObject> onActivationObjects) : base(name, ef, faction, row, points, onActivationObjects)
    {
        Appearances = 1;
        Score = 0;
        Type = "Decoy";
    }
}
//-----------------------------------------------------------------------------------------------
public class SpecialCard : Card
{

    public SpecialCard(string name, string ef, string row) : base(name, ef, row)
    {
        Faction = "Neutral";
        
    }
    public SpecialCard(string name, string ef, string row, List<OnActivationObject> onActivations) : base(name, ef, row, onActivations)
    {
        Faction = "Neutral";
    }
}
//-----------------------------------------------------------------------------------------------
public class Weather : SpecialCard
{

    public Weather(string name, string ef, string row) : base(name, ef, row)
    {
        Type = "Weather";
    }
    public Weather(string name, string ef, string row, List<OnActivationObject> onActivationObjects) : base(name, ef, row, onActivationObjects)
    {
        Type = "Weather";
    }

}
//----------------------------------------------------------------------------------------------
public class BonusCard : SpecialCard
{

    public BonusCard(string name, string ef, string row) : base(name, ef, row)
    {
        Type = "Bonus";
    }
    public BonusCard(string name, string ef, string row, List<OnActivationObject> onActivationObjects) : base(name, ef, row, onActivationObjects)
    {
        Type = "Bonus";
    }
}
//------------------------------------------------------------------------------------------------
public class Clearance : SpecialCard
{
    public Clearance(string name, string ef, string row) : base(name, ef, row)
    {
        Type = "Despeje";
    }
}
//------------------------------------------------------------------------------------------------
public class Lider : Card
{
    public Lider(string name, string ef, string faction, string row) : base(name, ef, row)
    {
        Type = "Lider";
        Faction = faction;
    }
}

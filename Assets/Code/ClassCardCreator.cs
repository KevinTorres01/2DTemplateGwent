using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
public class CardCreator
{
    public static List<Card> Cards = new List<Card>();
    public static List<Card> Liders => Cards.Where(x => (x.Type == "Lider")).ToList();
    public static void CreateCards()
    {
        List<Card> CardList = new List<Card>();

        Weather weather = new Weather("Advanced Fight", "WeatherM","M");
        CardList.Add(weather);
        SilverCard Android_17 = new SilverCard("Android 17", "Multiply", "Universe 7", "S", 5);
        CardList.Add(DuplicateCards(Android_17));
        UnitCard Android_17_1 = DuplicateCards(Android_17);
        CardList.Add(Android_17_1);
        UnitCard Android_17_2 = DuplicateCards(Android_17);
        CardList.Add(Android_17_2);
        SilverCard Android_18 = new SilverCard("Android 18", "DeletRivalWeek", "Universe 7", "RS", 4);
        CardList.Add(Android_18);
        UnitCard Android_18_1 = DuplicateCards(Android_18);
        CardList.Add(Android_18_1);
        UnitCard Android_18_2 = DuplicateCards(Android_18);
        CardList.Add(Android_18_2);
        BonusCard bonus = new BonusCard("Battlefield", "BonusM","M");
        CardList.Add(bonus);
        Weather Beerus_Planet = new Weather("Beerus Planet", "WeatherR","R");
        CardList.Add(Beerus_Planet);
        BonusCard Capsule_Corp = new BonusCard("Capsule corp", "BonusS","S");
        CardList.Add(Capsule_Corp);
        Lider Beerus_Sama = new Lider("Beerus Sama", "Average", "Universe 7","");
        CardList.Add(Beerus_Sama);
        GoldenCard Freeza = new GoldenCard("Freeza", "WeatherS", "Universe 7", "MR", 6);
        CardList.Add(Freeza);
        Clearance Genkidama = new Clearance("Genkidama", "CleanWeather","");
        CardList.Add(Genkidama);
        GoldenCard Gohan = new GoldenCard("Son Gohan", "Clean", "Universe 7", "MR", 6);
        CardList.Add(Gohan);
        BonusCard Kaio_Sama_Planet = new BonusCard("Kaio Sama Planet", "BonusR","R");
        CardList.Add(Kaio_Sama_Planet);
        Weather Kame_House = new Weather("Kame House", "WeatherS","S");
        CardList.Add(Kame_House);
        DecoyCard Card5 = new DecoyCard("Kuririn", " ", "Universe 7", "MRS", 0);
        CardList.Add(Card5);
        SilverCard Piccolo = new SilverCard("Piccolo", "BonusR", "Universe 7", "R", 4);
        CardList.Add(Piccolo);
        UnitCard Piccolo_1 = DuplicateCards(Piccolo);
        CardList.Add(Piccolo_1);
        UnitCard Piccolo_2 = DuplicateCards(Piccolo);
        CardList.Add(Piccolo_2);
        SilverCard Roshi = new SilverCard("Roshi Sensei", "Clean", "Universe 7", "RS", 3);
        CardList.Add(Roshi);
        UnitCard Roshi1 = DuplicateCards(Roshi);
        CardList.Add(Roshi1);
        UnitCard Roshi2 = DuplicateCards(Roshi);
        CardList.Add(Roshi2);
        GoldenCard Son_Goku = new GoldenCard("Son Goku", "DeletePowerful", "Universe 7", "M", 8);
        CardList.Add(Son_Goku);
        SilverCard Tien_Shinhan = new SilverCard("Tien Shinhan", "Draw", "Universe 7", "RS", 2);
        CardList.Add(Tien_Shinhan);
        UnitCard Tien_Shinhan_1 = DuplicateCards(Tien_Shinhan);
        CardList.Add(Tien_Shinhan_1);
        UnitCard Tien_Shinhan_2 = DuplicateCards(Tien_Shinhan);
        CardList.Add(Tien_Shinhan_2);
        GoldenCard goldenCard = new GoldenCard("Veggeta", "Average", "Universe 7", "M", 7);
        CardList.Add(goldenCard);
        foreach (var item in CardList)
        {
            Cards.Add(item);
        }

    }
    public static List<Card> CreateDeck(string Faction)
    {
        List<Card> CardList = new List<Card>();
        foreach (var item in Cards)
        {
            if (item.Faction == Faction || item.Faction == "Neutral")
            {
                CardList.Add(item);
            }
        }
        return CardList;
    }
    public static UnitCard DuplicateCards(UnitCard card)
    {
        UnitCard copy = new UnitCard("", "", "", "", 0);
        if (card is SilverCard silver)
        {
            copy = new SilverCard(card.Name, card.Effect, card.Faction, card.Possition, card.PowerPoints, card.onActivations);
        }
        else if (card is GoldenCard)
        {
            copy = new GoldenCard(card.Name, card.Effect, card.Faction, card.Possition, card.PowerPoints, card.onActivations);
        }
        else
        {
            copy = new DecoyCard(card.Name, card.Effect, card.Faction, card.Possition, card.PowerPoints, card.onActivations);
        }
        return copy;
    }
}

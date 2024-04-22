using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class CardCreator
{
    public static List<Card> CreateCards()
    {
        List<Card> CardList = new List<Card>();

        Weather weather = new Weather("Advanced Fight", "WeatherM");
        CardList.Add(weather);
        SilverCard Android_17 = new SilverCard("Android 17", "Multiply", "Universe 7", "S", 5);
        CardList.Add(Android_17);
        SilverCard Android_17_1 = DuplicateCards(Android_17);
        CardList.Add(Android_17_1);
        SilverCard Android_17_2 = DuplicateCards(Android_17);
        CardList.Add(Android_17_2);
        SilverCard Android_18 = new SilverCard("Android 18", "DeletRivalWeek", "Universe 7", "RS", 4);
        CardList.Add(Android_18);
        SilverCard Android_18_1 = DuplicateCards(Android_18);
        CardList.Add(Android_18_1);
        SilverCard Android_18_2 = DuplicateCards(Android_18);
        CardList.Add(Android_18_2);
        BonusCard bonus = new BonusCard("Battlefield", "BonusM");
        CardList.Add(bonus);
        Weather Beerus_Planet = new Weather("Beerus Planet", "WeatherR");
        CardList.Add(Beerus_Planet);
        BonusCard Capsule_Corp = new BonusCard("Capsule corp", "BonusS");
        CardList.Add(Capsule_Corp);
        Lider Beerus_Sama = new Lider("Beerus Sama", "", "Universe 7");
        CardList.Add(Beerus_Sama);
        GoldenCard Freeza = new GoldenCard("Freeza", "WeatherS", "Universe 7", "MR", 6);
        CardList.Add(Freeza);
        Clearance Genkidama = new Clearance("Genkidama", "CleanWeather");
        CardList.Add(Genkidama);
        GoldenCard Gohan = new GoldenCard("Son Gohan", "Clean", "Universe 7", "MR", 6);
        CardList.Add(Gohan);
        BonusCard Kaio_Sama_Planet = new BonusCard("Kaio Sama Planet", "BonusR");
        CardList.Add(Kaio_Sama_Planet);
        Weather Kame_House = new Weather("Kame House", "WeatherS");
        CardList.Add(Kame_House);
        DecoyCard Card5 = new DecoyCard("Kuririn", "", "Universe 7", "MRS", 0);
        CardList.Add(Card5);
        SilverCard Piccolo = new SilverCard("Piccolo", "BonusR", "Universe 7", "R", 4);
        CardList.Add(Piccolo);
        SilverCard Piccolo_1 = DuplicateCards(Piccolo);
        CardList.Add(Piccolo_1);
        SilverCard Piccolo_2 = DuplicateCards(Piccolo);
        CardList.Add(Piccolo_2);
        SilverCard Roshi = new SilverCard("Roshi Sensei", "Clean", "Universe 7", "RS", 3);
        CardList.Add(Roshi);
        SilverCard Roshi1 = DuplicateCards(Roshi);
        CardList.Add(Roshi1);
        SilverCard Roshi2 = DuplicateCards(Roshi);
        CardList.Add(Roshi2);
        GoldenCard Son_Goku = new GoldenCard("Son Goku", "DeletePowerful", "Universe 7", "M", 8);
        CardList.Add(Son_Goku);
        SilverCard Tien_Shinhan = new SilverCard("Tien Shinhan","Draw","Universe 7","RS",2);
        CardList.Add(Tien_Shinhan);
        SilverCard Tien_Shinhan_1 = DuplicateCards(Tien_Shinhan);
        CardList.Add(Tien_Shinhan_1);
        SilverCard Tien_Shinhan_2 = DuplicateCards(Tien_Shinhan);
        CardList.Add(Tien_Shinhan_2);
        GoldenCard goldenCard = new GoldenCard("Veggeta", "Average", "Universe 7", "M", 7);
        CardList.Add(goldenCard);

        return CardList;

    }
    public static List<Card> CreateDeck(string Faction)
    {
        List<Card> CardList = new List<Card>();
        foreach (var item in CardCreator.CreateCards())
        {
            if (item.Faction == Faction||item.Faction == "Neutral")
            {
                CardList.Add(item);
            }
            
        }
        return CardList;
    } 
    private static SilverCard DuplicateCards(SilverCard card)
    {
        SilverCard copy = new SilverCard(card.Name, card.Effect, card.Faction, card.Possition, card.PowerPoints);
        return copy;
    }
}

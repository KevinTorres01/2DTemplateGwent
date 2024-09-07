using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
public abstract class Effects
{
    public static Dictionary<string, Effects> GiveEffect { get; set; } = Fill();
    protected static Dictionary<string, CompiledEffect> CompiledEffects = new Dictionary<string, CompiledEffect>();
    public Effects()
    {

    }
    public static void AddCompilatedEffect(CompiledEffect effect)
    {
        if (CompiledEffects.ContainsKey(effect.Name))
        {
            return;
        }
        CompiledEffects.Add(effect.Name, effect);
    }
    static Dictionary<string, Effects> Fill()
    {
        Dictionary<string, Effects> ef = new Dictionary<string, Effects>();
        ef.Add("Multiply", new Multiply());
        ef.Add("DeletRivalWeek", new DeletRivalWeak());
        ef.Add("DeletePowerful", new DeletPowerful());
        ef.Add("Draw", new Draw());
        ef.Add("Clean", new Clean());
        ef.Add("BonusR", new BonificationR());
        ef.Add("BonusS", new BonificationS());
        ef.Add("BonusM", new BonificationM());
        ef.Add("Average", new Averages());
        ef.Add("WeatherR", new WeatherEffect_R());
        ef.Add("WeatherM", new WeatherEffect_M());
        ef.Add("WeatherS", new WeatherEffect_S());
        ef.Add("CleanWeather", new CleanWeather());
        ef.Add(" ", new Empty());
        ef.Add("", new PersonalizedEffect());
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

        if (player.IsMyturn)
        {
            for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player.boardPlayer.UnitCards[i])
                {
                    if (item == unitCard)
                    {
                        item.Score = item.Score * count;
                        return;
                    }
                }
            }

        }
        if (player1.IsMyturn)
        {
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player1.boardPlayer.UnitCards[i])
                {
                    if (item == unitCard)
                    {
                        item.Score = item.Score * count;
                        return;
                    }
                }
            }

        }

        Debug.Log($"efecto hecho");
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
            UnitCard weak = Board.GetWeakCard(player1.boardPlayer.UnitCards);
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player1.boardPlayer.UnitCards[i])
                {
                    if (weak.Score == item.Score && item.Type == "Silver")
                    {
                        Debug.Log($"la carta {item.Name} fue eliminada");
                        player1.Graveyard.Add(item);
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
        if (player.IsMyturn && PowerfulP.Score == PowerfulP1.Score)
        {
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player1.boardPlayer.UnitCards[i])
                {
                    if (item.Score == PowerfulP.Score && item.Type == "Silver")
                    {
                        player1.Graveyard.Add(item);
                        player1.boardPlayer.UnitCards[i].Remove(item);
                        Debug.Log($"la carta {item.Name} fue eliminada");
                        return;
                    }
                }
            }

        }
        if (player1.IsMyturn && PowerfulP.Score == PowerfulP1.Score)
        {
            for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player.boardPlayer.UnitCards[i])
                {
                    if (item.Score == PowerfulP.Score && item.Type == "Silver")
                    {
                        player.Graveyard.Add(item);
                        player.boardPlayer.UnitCards[i].Remove(item);
                        Debug.Log($"la carta {item.Name} fue eliminada");
                        return;
                    }
                }

            }

        }
        if (PowerfulP.Score != PowerfulP1.Score)
        {
            UnitCard p = PowerfulP.Score > PowerfulP1.Score ? PowerfulP : PowerfulP1;
            for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player.boardPlayer.UnitCards[i])
                {
                    if (item.Score == p.Score)
                    {
                        player.boardPlayer.UnitCards[i].Remove(item);
                        Debug.Log($"la carta {item.Name} fue eliminada");
                        return;
                    }
                }
            }
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in player1.boardPlayer.UnitCards[i])
                {
                    if (item.Score == p.Score)
                    {
                        player1.boardPlayer.UnitCards[i].Remove(item);
                        Debug.Log($"la carta {item.Name} fue eliminada");
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
        if (player1.IsMyturn)
        {
            if (player1.Hand.ListOfCards.Count <= 10)
            {
                player1.Hand.ListOfCards.Add(player1.Playerdeck.DeckList[0]);
                player1.Playerdeck.DeckList.Remove(player1.Playerdeck.DeckList[0]);
                Debug.Log("Robo la carta en el backend");
            }
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


        int count = 0;

        if (player.IsMyturn)
        {
            for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
            {
                if (player1.boardPlayer.UnitCards[i].Count == value)
                {
                    for (int j = player1.boardPlayer.UnitCards[i].Count - 1; j >= 0; j--)
                    {
                        if (player1.boardPlayer.UnitCards[i][j] is SilverCard)
                        {

                            Debug.Log("Se Elimino la carta" + player1.boardPlayer.UnitCards[i][j].Name);
                            player1.boardPlayer.UnitCards[i].RemoveAt(j);
                            count++;
                        }
                    }
                    if (count != 0)
                    {
                        break;
                    }
                }
            }

            if (count == 0)
            {
                for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
                {
                    if (player.boardPlayer.UnitCards[i].Count == value)
                    {
                        for (int j = player.boardPlayer.UnitCards[i].Count - 1; j >= 0; j--)
                        {
                            if (player.boardPlayer.UnitCards[i][j] is SilverCard)
                            {
                                Debug.Log("Se Elimino la carta" + player.boardPlayer.UnitCards[i][j].Name);
                                player.boardPlayer.UnitCards[i].RemoveAt(j);
                                count++;
                            }
                        }
                        if (count != 0)
                        {

                            break;
                        }
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
        Debug.Log($"efecto hecho");
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
                if (player.boardPlayer.bonus[1] != null)
                {
                    item.Score += 3;
                }
            }
        }
        foreach (var item in player1.boardPlayer.UnitCards[1])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
                if (player1.boardPlayer.bonus[1] != null)
                {
                    item.Score += 3;
                }
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
                if (player.boardPlayer.bonus[0] != null)
                {
                    item.Score += 3;
                }
            }
        }
        foreach (var item in player1.boardPlayer.UnitCards[0])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
                if (player1.boardPlayer.bonus[0] != null)
                {
                    item.Score += 3;
                }
            }
        }
    }
}
//-------------------------------------------------------------------------------------------------------
class WeatherEffect_S : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
        WeatherS(player, player1, unitCard);
    }
    static void WeatherS(Player player, Player player1, Card unitCard)
    {
        foreach (var item in player.boardPlayer.UnitCards[2])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
                if (player.boardPlayer.bonus[2] != null)
                {
                    item.Score += 3;
                }
            }
        }
        foreach (var item in player1.boardPlayer.UnitCards[2])
        {
            if (item.Type == "Silver")
            {
                item.Score = 1;
                if (player1.boardPlayer.bonus[2] != null)
                {
                    item.Score += 3;
                }
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
        for (int i = 0; i < player.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player.boardPlayer.UnitCards[i])
            {
                item.Score = item.PowerPoints;
            }
        }
        for (int i = 0; i < player1.boardPlayer.UnitCards.Length; i++)
        {
            foreach (var item in player1.boardPlayer.UnitCards[i])
            {
                item.Score = item.PowerPoints;
            }
        }
    }
}
class PersonalizedEffect : Effects
{
    public override void ActivateEffect(Player player, Player player1, Card unitCard)
    {
if (unitCard.onActivations==null)
{
    Debug.Log("nullllllll");
}
        foreach (var item in unitCard.onActivations)
        {
            ExecuteOnActivation(item);
        }
    }

    private void ExecuteOnActivation(OnActivationObject item)
    {
        var x = new Context();
        CompiledEffects[item.EffectInfo.name].action.Invoke(x, GetTargets(x, item));
        if (item.postaction != null)
        {
            ExecuteOnActivation(item.postaction);
        }
    }
    private List<Card> GetTargets(Context context, OnActivationObject onActivation, OnActivationObject parent = null)
    {
        var sour = onActivation.Selector.source;
        List<Card> targets = sour == "hand" ? context.Hand : sour == "otherHand" ? context.HandOfPlayer((context.TrigerPlayer + 1) % 2) : sour == "deck" ? context.Deck : sour == "otherDeck" ? context.DeckOfPlayer((context.TrigerPlayer + 1) % 2) :
        sour == "field" ? context.Field : sour == "otherField" ? context.FieldOfPlayer((context.TrigerPlayer + 1) % 2) : new();
        if (sour == "parent")
        {
            sour = parent.Selector.source;
            targets = sour == "hand" ? context.Hand : sour == "otherHand" ? context.HandOfPlayer((context.TrigerPlayer + 1) % 2) : sour == "deck" ? context.Deck : sour == "otherDeck" ? context.DeckOfPlayer((context.TrigerPlayer + 1) % 2) :
                   sour == "field" ? context.Field : sour == "otherField" ? context.FieldOfPlayer((context.TrigerPlayer + 1) % 2) : new();
        }
        List<Card> cards = new();
        foreach (var item in targets)
        {
            if ((bool)onActivation.Selector.Delegate.Invoke(item))
            {
                cards.Add(item);
            }
        }
        if (onActivation.Selector.single)
        {
            return cards.Count == 0 ? cards : new List<Card> { cards[0] };
        }
        else
        {
            return cards;
        }

    }
}
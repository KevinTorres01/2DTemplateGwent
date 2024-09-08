using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class CardVisual : MonoBehaviour
{
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Effect;
    public UnityEngine.UI.Image Base;
    public UnityEngine.UI.Image Character;
    public VerticalLayoutGroup Ranges;
    public GameObject RangePrefab;
    public Card Card;

    public void ChangeImage(Card card)                     //  le asigna la imagen a la carta en el visual
    {
        Card = card;

        Character.sprite = Resources.Load<Sprite>("Card Image/" + GetCaracterImage(card));

        if (Card is UnitCard unitCard)
        {
            if (unitCard is SilverCard)
                Base.sprite = Resources.Load<Sprite>("SilverCardBase");
            else Base.sprite = Resources.Load<Sprite>("HeroCardBase");
            //Points.text = unitCard.Score.ToString();
            Name.text = Card.Name;
            if (unitCard.Possition.Contains("M"))
            {
                var range = Instantiate(RangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                range.transform.SetParent(Ranges.transform);
                range.transform.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Melee");
            }
            if (unitCard.Possition.Contains("R"))
            {
                var range = Instantiate(RangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                range.transform.SetParent(Ranges.transform);
                range.transform.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Ranged");
            }
            if (unitCard.Possition.Contains("S"))
            {
                var range = Instantiate(RangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                range.transform.SetParent(Ranges.transform);
                range.transform.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Siege");
            }
        }
        else
        {
            Base.sprite = Resources.Load<Sprite>("CardBase");
            //Points.text = " ";
            Name.text = Card.Type + " : " + Card.Name;
        }

        Effect.text = Card.Effect;
    }
    public void SetPoints(Card card)                       //   le asigna los puntos a la carta en el visual
    {
        if (card is UnitCard unitCard)
        {
            Points.text = unitCard.Score.ToString();
        }
        else Points.text = " ";
    }
    public string GetCaracterImage(Card card)
    {
        int min = int.MaxValue;
        string NameOfPic = "";
        var AllFiles = Directory.EnumerateFiles("Assets/Resources/Card Image", "*.png");
        foreach (var item in AllFiles)
        {
            string FileName = Path.GetFileName(item);
            FileName = Path.ChangeExtension(FileName, null);
            int levenshtein = LevenshteinDistance(FileName, card.Name);
            if (levenshtein < min)
            {
                NameOfPic = FileName;
                min = levenshtein;
            }
        }
        return NameOfPic;
    }
    public int LevenshteinDistance(string First, string Second)
    {
        int cost = 0;
        int m = First.Length;
        int n = Second.Length;
        int[,] dp = new int[m + 1, n + 1];
        if (m == 0 || n == 0)
            return 0;

        for (int i = 0; i <= m;)
            dp[i, 0] = i++;

        for (int j = 0; j <= n;)
            dp[0, j] = j++;


        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                cost = First[i - 1] == Second[j - 1] ? 0 : 1;
                dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
            }
        }

        return dp[m, n];
    }

}

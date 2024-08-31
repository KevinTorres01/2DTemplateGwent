using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class GameManager : MonoBehaviour                                        // Crea los jugadores, verifica si los jugadores ya pasaron o no,
{                                                                               // escoge un ganador y anade sus victorias en backend y fronten
    public UnityEngine.UI.Image Final;                                           // destruye las cartas del fronten cuando termina una ronda y cuando no estan en el tablero  del backend las detruye en el fronten
    public TextMeshProUGUI FinalMessage;                                         //  decide cuando  una ronda termina
    [SerializeField] public TextMeshProUGUI UIMessage;                           //  crea nuevas ronda
    public UnityEngine.UI.Image FirstWin1;
    public UnityEngine.UI.Image FirstWin2;
    public UnityEngine.UI.Image SecondWin1;
    public UnityEngine.UI.Image SecondWin2;
    public HorizontalLayoutGroup M1;
    public HorizontalLayoutGroup R1;
    public HorizontalLayoutGroup S1;
    public HorizontalLayoutGroup BonusM1;
    public HorizontalLayoutGroup BonusR1;
    public HorizontalLayoutGroup BonusS1;
    public HorizontalLayoutGroup M2;
    public HorizontalLayoutGroup R2;
    public HorizontalLayoutGroup S2;
    public HorizontalLayoutGroup BonusM2;
    public HorizontalLayoutGroup BonusR2;
    public HorizontalLayoutGroup BonusS2;
    public HorizontalLayoutGroup WeatherM;
    public HorizontalLayoutGroup WeatherR;
    public HorizontalLayoutGroup WeatherS;
    public GameObject Hand1;
    public GameObject Hand2;
    public static Player player1;
    public static Player player2;
    public static GameManager gameManager;
    void Awake()
    {
        player1 = GameData.Player1;
        player2 = GameData.Player2;
        WhoStart(player1, player2);
    }
    void Destroyer()
    {
        for (int i = 0; i < WeatherM.transform.childCount; i++)
        {
            Destroy(WeatherM.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < WeatherR.transform.childCount; i++)
        {
            Destroy(WeatherR.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < WeatherS.transform.childCount; i++)
        {
            Destroy(WeatherS.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < M1.transform.childCount; i++)
        {
            Destroy(M1.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < R1.transform.childCount; i++)
        {
            Destroy(R1.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < S1.transform.childCount; i++)
        {
            Destroy(S1.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < M2.transform.childCount; i++)
        {
            Destroy(M2.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < R2.transform.childCount; i++)
        {
            Destroy(R2.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < S2.transform.childCount; i++)
        {
            Destroy(S2.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < BonusM1.transform.childCount; i++)
        {
            Destroy(BonusM1.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < BonusR1.transform.childCount; i++)
        {
            Destroy(BonusR1.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < BonusS1.transform.childCount; i++)
        {
            Destroy(BonusS1.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < BonusM2.transform.childCount; i++)
        {
            Destroy(BonusM2.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < BonusR2.transform.childCount; i++)
        {
            Destroy(BonusR2.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < BonusS2.transform.childCount; i++)
        {
            Destroy(BonusS2.transform.GetChild(i).gameObject);
        }
    }
    void Start()
    {
        Final.gameObject.SetActive(false);
        FirstWin1.gameObject.SetActive(false);
        SecondWin1.gameObject.SetActive(false);
        FirstWin2.gameObject.SetActive(false);
        SecondWin2.gameObject.SetActive(false);
        gameManager = this;
    }
    async public void SetVictory()
    {
        if (player1.IsMyturn == false && player2.IsMyturn == false && player1.boardPlayer.score > player2.boardPlayer.score)
        {
            Victory(player1);
            UIMessage.text = $"{player1.Name} ha ganado la ronda";
            await Task.Delay(2000);
            player1.IsMyturn = true;
            UIMessage.text = $"Turno de {player1.Name}";
            Hand1.GetComponent<HandScript>().DrawTwoCards(player1);
            Hand2.GetComponent<HandScript>().DrawTwoCards(player2);
            NewRound();

        }
        if (player1.IsMyturn == false && player2.IsMyturn == false && player2.boardPlayer.score > player1.boardPlayer.score)
        {
            Victory(player2);
            UIMessage.text = $"{player2.Name} ha ganado la ronda";
            await Task.Delay(2000);
            player2.IsMyturn = true;
            UIMessage.text = $"Turno de {player2.Name}";
            Hand1.GetComponent<HandScript>().DrawTwoCards(player1);
            Hand2.GetComponent<HandScript>().DrawTwoCards(player2);
            NewRound();
        }
        if (player1.IsMyturn == false && player2.IsMyturn == false && player2.boardPlayer.score == player1.boardPlayer.score)
        {
            Victory(player1);
            Victory(player2);
            UIMessage.text = $"{player1.Name} y {player2.Name} han empatado";
            WhoStart(player1, player2);
            Hand1.GetComponent<HandScript>().DrawTwoCards(player1);
            Hand2.GetComponent<HandScript>().DrawTwoCards(player2);
            NewRound();
        }
        Board.CleanBoard(player1, player2);
        Destroyer();

    }
    void NewRound()
    {
        player1.Pased = false;
        player2.Pased = false;
    }

    static void Victory(Player player)
    {
        player.Victories++;
    }

    void WhoStart(Player player1, Player player2)
    {
        System.Random random = new System.Random();
        int a = random.Next(0, 3);
        if (a % 2 == 1)
        {
            player2.IsMyturn = true;
            UIMessage.text = $"Turno de {player2.Name}";
        }
        else
        {
            player1.IsMyturn = true;
            UIMessage.text = $"Turno de {player1.Name}";
        }

    }

    async public void PassTurn()
    {
        if (player1.IsMyturn)
        {
            player1.Pased = true;
            player1.IsMyturn = false;
            if (player2.Pased == false)
            {
                player2.IsMyturn = true;
                UIMessage.text = $"Turno de {player2.Name}";
            }
            else
            {
                UIMessage.text = "La ronda ha terminado";
                await Task.Delay(2000);
                SetVictory();
            }
        }
        else
        {
            player2.Pased = true;
            player2.IsMyturn = false;
            if (player1.Pased == false)
            {
                player1.IsMyturn = true;
                UIMessage.text = $"Turno de {player1.Name}";
            }
            else
            {
                UIMessage.text = "La ronda ha terminado";
                await Task.Delay(2000);
                SetVictory();
            }

        }
        if (player1.Victories == 2 || player2.Victories == 2)
        {
            FinishGame();
        }
    }

    async void FinishGame()
    {
        await Task.Delay(2000);
        if (player1.Victories == 2 && player2.Victories == 2)
        {
            FinalMessage.text = "Los jugadores han empatado";
        }

        else if (player2.Victories > player1.Victories)
        {
            FinalMessage.text = $"{player2.Name} ha ganado la partida";
        }

        else
        {
            FinalMessage.text = $"{player1.Name} ha ganado la partida";
        }

        Final.gameObject.SetActive(true);

        await Task.Delay(10000);
        GameData.ResetData();
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        GameManager.gameManager.ActPointsInFronten();
        if (player1.Victories == 1)
        {
            FirstWin1.gameObject.SetActive(true);

        }
        if (player2.Victories == 1)
        {
            FirstWin2.gameObject.SetActive(true);

        }
        if (player1.Victories == 2)
        {
            SecondWin1.gameObject.SetActive(true);

        }
        if (player2.Victories == 2)
        {
            SecondWin2.gameObject.SetActive(true);


        }
        if (player1.Victories == 2 || player2.Victories == 2)
        {
            player2.IsMyturn = false;
            player1.IsMyturn = false;
            UIMessage.text = "La partida ha terminado";
        }
    }

    public void ActPointsInFronten()
    {
        for (int i = 0; i < M1.transform.childCount; i++)
        {
            Card CardToSearch = M1.transform.GetChild(i).GetComponent<CardVisual>().Card;
            if (CardToSearch is UnitCard unitCard && player1.boardPlayer.UnitCards[0].Contains(unitCard))
            {
                M1.transform.GetChild(i).GetComponent<CardVisual>().SetPoints(unitCard);
            }
            else
            {
                Destroy(M1.transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < M2.transform.childCount; i++)
        {
            Card CardToSearch = M2.transform.GetChild(i).GetComponent<CardVisual>().Card;
            if (CardToSearch is UnitCard unitCard && player2.boardPlayer.UnitCards[0].Contains(unitCard))
            {
                M2.transform.GetChild(i).GetComponent<CardVisual>().SetPoints(unitCard);

            }
            else
            {
                Destroy(M2.transform.GetChild(i).gameObject);

            }
        }
        for (int i = 0; i < R2.transform.childCount; i++)
        {
            Card CardToSearch = R2.transform.GetChild(i).GetComponent<CardVisual>().Card;
            if (CardToSearch is UnitCard unitCard && player2.boardPlayer.UnitCards[1].Contains(unitCard))
            {
                R2.transform.GetChild(i).GetComponent<CardVisual>().SetPoints(unitCard);

            }
            else
            {
                Destroy(R2.transform.GetChild(i).gameObject);

            }
        }
        for (int i = 0; i < R1.transform.childCount; i++)
        {
            Card CardToSearch = R1.transform.GetChild(i).GetComponent<CardVisual>().Card;
            if (CardToSearch is UnitCard unitCard && player1.boardPlayer.UnitCards[1].Contains(unitCard))
            {
                R1.transform.GetChild(i).GetComponent<CardVisual>().SetPoints(unitCard);

            }
            else
            {
                Destroy(R1.transform.GetChild(i).gameObject);

            }
        }
        for (int i = 0; i < S1.transform.childCount; i++)
        {
            Card CardToSearch = S1.transform.GetChild(i).GetComponent<CardVisual>().Card;
            if (CardToSearch is UnitCard unitCard && player1.boardPlayer.UnitCards[2].Contains(unitCard))
            {
                S1.transform.GetChild(i).GetComponent<CardVisual>().SetPoints(unitCard);

            }
            else
            {
                Destroy(S1.transform.GetChild(i).gameObject);

            }
        }
        for (int i = 0; i < S2.transform.childCount; i++)
        {
            Card CardToSearch = S2.transform.GetChild(i).GetComponent<CardVisual>().Card;
            if (CardToSearch is UnitCard unitCard && player2.boardPlayer.UnitCards[2].Contains(unitCard))
            {
                S2.transform.GetChild(i).GetComponent<CardVisual>().SetPoints(unitCard);

            }
            else
            {
                Destroy(S2.transform.GetChild(i).gameObject);
            }
        }
    }

    public void DestroyWeathers()
    {
        if (WeatherM.transform.childCount > 0)
        {
            Destroy(WeatherM.transform.GetChild(0).gameObject);
        }
        if (WeatherR.transform.childCount > 0)
        {
            Destroy(WeatherR.transform.GetChild(0).gameObject);
        }
        if (WeatherS.transform.childCount > 0)
        {
            Destroy(WeatherS.transform.GetChild(0).gameObject);
        }
    }
    public static void CreateCompiledCards()
    {
        string ToCompile = GetFileContent("/home/kevin/Subiendo proyecto/2DTemplate/Assets/Text/Text");
        var x = Compiler.Compile(ToCompile);
        Debug.Log("Compilo");
        foreach (var item in x.cards.Keys)
        {
            string name = x.cards[item].Name;
            int power = Convert.ToInt32(x.cards[item].Power);
            string Range = x.cards[item].Range;
            string Type = x.cards[item].Type;
            string Faction = x.cards[item].Faction;
            if (Type == "Silver")
            {
                SilverCard silverCard = new SilverCard(name, "", Faction, Range, power);
                CardCreator.Cards.Add(silverCard);
                CardCreator.Cards.Add(CardCreator.DuplicateCards(silverCard));
                CardCreator.Cards.Add(CardCreator.DuplicateCards(silverCard));
            }
            if (Type == "Golden")
            {
                GoldenCard goldenCard = new GoldenCard(name, "", Faction, Range, power);
                CardCreator.Cards.Add(goldenCard);
            }
            Debug.Log("carta creada " + name);
        }

    }
    private static string GetFileContent(string root)
    {
        StreamReader streamReader = new StreamReader(root);
        string FileContent = streamReader.ReadToEnd();
        streamReader.Close();
        return FileContent;
    }
}

using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeCards : MonoBehaviour
{
    public GameObject CardButton;
    public TextMeshProUGUI PlayerName;
    int changedCardsCountP1 = 0;
    int changedCardsCountP2 = 0;

    private static bool[] playerIsReady = new bool[2];

    void Start()
    {
        if (this.name == "Player1Hand")       // roba 1 carta cuando se  activa el efecto robar una carta
        {
            List<Card> hand = GameData.Player1.Hand.ListOfCards;
            PlayerName.text = GameData.Player1Name;

            for (int i = 0; i < 10; i++)
            {
                var card = Instantiate(CardButton, this.transform);
                card.GetComponent<CardVisual>().ChangeImage(hand[i]);
                card.GetComponent<CardVisual>().SetPoints(hand[i]);
                UnityEngine.Debug.Log(hand[i].Name);
            }
        }

        if (this.name == "Player2Hand")
        {
            List<Card> hand1 = GameData.Player2.Hand.ListOfCards;
            PlayerName.text = GameData.Player2Name;

            for (int i = 0; i < 10; i++)
            {
                var card = Instantiate(CardButton, this.transform);
                card.GetComponent<CardVisual>().ChangeImage(hand1[i]);
                card.GetComponent<CardVisual>().SetPoints(hand1[i]);
                UnityEngine.Debug.Log(hand1[i].Name);
            }
        }
    }


    public void ChangeCard(CardVisual cardVisual)
    {
        if (cardVisual.transform.parent.name == "Player1Hand")
        {
            changedCardsCountP1++;
            if (changedCardsCountP1 <= 2)
            {
                GameData.gameData.ChangeCard(GameData.Player1, cardVisual.Card);
                Destroy(cardVisual.gameObject);
                var card = Instantiate(CardButton, this.transform);
                var newCard = GameData.Player1.Hand.ListOfCards.Last();
                card.GetComponent<CardVisual>().ChangeImage(newCard);
                card.GetComponent<CardVisual>().SetPoints(newCard);
            }
        }

        if (cardVisual.transform.parent.name == "Player2Hand")
        {
            changedCardsCountP2++;
            if (changedCardsCountP2 <= 2)
            {
                GameData.gameData.ChangeCard(GameData.Player2, cardVisual.Card);
                Destroy(cardVisual.gameObject);
                var card = Instantiate(CardButton, this.transform);
                var newCard = GameData.Player2.Hand.ListOfCards.Last();
                card.GetComponent<CardVisual>().ChangeImage(newCard);
                card.GetComponent<CardVisual>().SetPoints(newCard);
            }
        }
    }

    public static void Ready(int player)
    {
        playerIsReady[player] = true;

        if (playerIsReady[0] && playerIsReady[1]){
            playerIsReady[0] = playerIsReady[1] = false;
            SceneManager.LoadScene("Battlefield");
            
        }
    }


}

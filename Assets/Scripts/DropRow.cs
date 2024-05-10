using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DropRow : MonoBehaviour, IDropHandler
{
    public string NameOfRow;
    [SerializeField] public TextMeshProUGUI UIMessage;

    public void OnDrop(PointerEventData eventData)
    {
        if (this.transform.childCount < 6 && Drag.DraggedCard.GetComponent<CardVisual>().Card is UnitCard unitCard && unitCard.Possition.Contains(NameOfRow) && Drag.OriginalParent.parent.name == this.transform.parent.name)
        {
            Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;                                                     // Compruebo si la carta es valida ponerla en las filas, ademas anhado las cartas en
            Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
            Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;                    // el backend en el tablero, la remuevo del deck y hago el efecto teniendo en cuenta si hay climas o aumntos jugados
            Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;                    // ademas actualizo los puntos de las cartas y el tablero en el backend
            Drag.DraggedCard.GetComponent<Drag>().enabled = false;
            if (this.transform.parent.name == "Player1")
            {
                int count = GameManager.player1.Hand.ListOfCards.Count - 1;
                if (NameOfRow == "M")
                    PlayCard(GameManager.player1, unitCard, 0);

                if (NameOfRow == "S")
                    PlayCard(GameManager.player1, unitCard, 2);

                if (NameOfRow == "R")
                    PlayCard(GameManager.player1, unitCard, 1);

                GameManager.player1.Hand.ListOfCards.Remove(unitCard);

                if (Drag.DraggedCard.transform.GetComponent<CardVisual>().Card.Effect == "Draw" && GameManager.player1.Hand.ListOfCards.Count > count)
                {
                    Drag.OriginalParent.GetComponent<HandScript>().DrawACArd(GameManager.player1);
                }

                Board.UpdatePoints(GameManager.player1.boardPlayer);
                Board.UpdatePoints(GameManager.player2.boardPlayer);
                GameManager.gameManager.ActPointsInFronten();
            }

            if (this.transform.parent.name == "Player2")
            {
                int count = GameManager.player2.Hand.ListOfCards.Count - 1;
                if (NameOfRow == "M")
                    PlayCard(GameManager.player2, unitCard, 0);

                if (NameOfRow == "S")
                    PlayCard(GameManager.player2, unitCard, 2);

                if (NameOfRow == "R")
                    PlayCard(GameManager.player2, unitCard, 1);

                GameManager.player2.Hand.ListOfCards.Remove(unitCard);

                if (Drag.DraggedCard.transform.GetComponent<CardVisual>().Card.Effect == "Draw" && GameManager.player2.Hand.ListOfCards.Count > count)
                {
                    Drag.OriginalParent.GetComponent<HandScript>().DrawACArd(GameManager.player2);
                }

                Board.UpdatePoints(GameManager.player1.boardPlayer);
                Board.UpdatePoints(GameManager.player2.boardPlayer);
                GameManager.gameManager.ActPointsInFronten();
            }

            if (this.transform.parent.name == "Player1" && GameManager.player2.Pased == false)
            {
                GameManager.player1.IsMyturn = false;
                GameManager.player2.IsMyturn = true;
                UIMessage.text = $"Turno de {GameManager.player2.Name}";
            }

            if (this.transform.parent.name == "Player2" && GameManager.player1.Pased == false)
            {
                GameManager.player1.IsMyturn = true;
                GameManager.player2.IsMyturn = false;
                UIMessage.text = $"Turno de {GameManager.player1.Name}";
            }

        }
    }

    private static void PlayCard(Player player, UnitCard unitCard, int row)
    {
        player.boardPlayer.UnitCards[row].Add(unitCard);

        Board.ActPointsInRow(GameManager.player1.boardPlayer, GameManager.player2.boardPlayer, row);
        Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);
        Board.ActPointsInRow(GameManager.player1.boardPlayer, GameManager.player2.boardPlayer, row);
    }
}

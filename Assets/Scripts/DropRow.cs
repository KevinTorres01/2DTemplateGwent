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
            Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
            Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
            Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
            Drag.DraggedCard.GetComponent<Drag>().enabled = false;
            if (this.transform.parent.name == "Player1")
            {
                if (NameOfRow == "M")
                {
                    GameManager.player1.boardPlayer.UnitCards[0].Add(unitCard);
                    if (Board.BothPlayersWeather[0] != null)
                    {
                        unitCard.Score = 1;
                    }
                    if (GameManager.player1.boardPlayer.bonus[0] != null)
                    {
                        unitCard.Score += 3;
                    }
                    GameManager.player1.Hand.ListOfCards.Remove(unitCard);
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);
                    if (Drag.DraggedCard.transform.GetComponent<CardVisual>().Card.Effect == "Draw")
                    {
                        Drag.OriginalParent.GetComponent<HandScript>().DrawACArd(GameManager.player1);
                    }

                }
                if (NameOfRow == "S")
                {
                    GameManager.player1.boardPlayer.UnitCards[2].Add(unitCard);
                     if (Board.BothPlayersWeather[2] != null)
                    {
                        unitCard.Score = 1;
                    }
                    if (GameManager.player1.boardPlayer.bonus[2] != null)
                    {
                        unitCard.Score += 3;
                    }
                    GameManager.player1.Hand.ListOfCards.Remove(unitCard);
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);
                    if (Drag.DraggedCard.transform.GetComponent<CardVisual>().Card.Effect == "Draw")
                    {
                        Drag.OriginalParent.GetComponent<HandScript>().DrawACArd(GameManager.player1);
                    }

                }
                if (NameOfRow == "R")
                {
                    GameManager.player1.boardPlayer.UnitCards[1].Add(unitCard);
                     if (Board.BothPlayersWeather[1] != null)
                    {
                        unitCard.Score = 1;
                    }
                    if (GameManager.player1.boardPlayer.bonus[1] != null)
                    {
                        unitCard.Score += 3;
                    }
                    GameManager.player1.Hand.ListOfCards.Remove(unitCard);
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);
                    if (Drag.DraggedCard.transform.GetComponent<CardVisual>().Card.Effect == "Draw")
                    {
                        Drag.OriginalParent.GetComponent<HandScript>().DrawACArd(GameManager.player1);
                    }

                }
                Board.UpdatePoints(GameManager.player1.boardPlayer);
                Board.UpdatePoints(GameManager.player2.boardPlayer);

            }
            if (this.transform.parent.name == "Player2")
            {
                if (NameOfRow == "M")
                {
                    GameManager.player2.boardPlayer.UnitCards[0].Add(unitCard);
                     if (Board.BothPlayersWeather[0] != null)
                    {
                        unitCard.Score = 1;
                    }
                    if (GameManager.player2.boardPlayer.bonus[0] != null)
                    {
                        unitCard.Score += 3;
                    }
                    GameManager.player2.Hand.ListOfCards.Remove(unitCard);
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);
                    if (Drag.DraggedCard.transform.GetComponent<CardVisual>().Card.Effect == "Draw")
                    {
                        Drag.OriginalParent.GetComponent<HandScript>().DrawACArd(GameManager.player2);
                    }

                }
                if (NameOfRow == "S")
                {
                    GameManager.player2.boardPlayer.UnitCards[2].Add(unitCard);
                     if (Board.BothPlayersWeather[2] != null)
                    {
                        unitCard.Score = 1;
                    }
                    if (GameManager.player2.boardPlayer.bonus[2] != null)
                    {
                        unitCard.Score += 3;
                    }
                    GameManager.player2.Hand.ListOfCards.Remove(unitCard);
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);
                    if (Drag.DraggedCard.transform.GetComponent<CardVisual>().Card.Effect == "Draw")
                    {
                        Drag.OriginalParent.GetComponent<HandScript>().DrawACArd(GameManager.player2);
                    }

                }
                if (NameOfRow == "R")
                {
                    GameManager.player2.boardPlayer.UnitCards[1].Add(unitCard);
                     if (Board.BothPlayersWeather[1] != null)
                    {
                        unitCard.Score = 1;
                    }
                    if (GameManager.player2.boardPlayer.bonus[1] != null)
                    {
                        unitCard.Score += 3;
                    }
                    GameManager.player2.Hand.ListOfCards.Remove(unitCard);
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);
                    if (Drag.DraggedCard.transform.GetComponent<CardVisual>().Card.Effect == "Draw")
                    {
                        Drag.OriginalParent.GetComponent<HandScript>().DrawACArd(GameManager.player2);
                    }

                }
                Board.UpdatePoints(GameManager.player1.boardPlayer);
                Board.UpdatePoints(GameManager.player2.boardPlayer);
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
}

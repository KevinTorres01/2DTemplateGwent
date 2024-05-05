using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public string NameofSlot;
    public bool WasDropped = false;
    [SerializeField] public TextMeshProUGUI UIMessage;
    public void OnDrop(PointerEventData eventData)                                      // compruebo si es posible poner la carta en el slot, la anado a su posicion en el backend
    {
        if (this.transform.childCount == 0)                                             // activo el efecto y elimino la carta de su posicion en la mano
        {

            if (Drag.DraggedCard.GetComponent<CardVisual>().Card is Weather weather1 && this.transform.parent.name == "WeatherRow")
            {
                if (weather1.Effect.Contains("M") && NameofSlot == "M")
                {
                    Board.BothPlayersWeather[0] = weather1;
                    Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                    Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                    Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                    Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);
                    
                    WasDropped = true;
                }
                if (weather1.Effect.Contains("R") && NameofSlot == "R")
                {
                    Board.BothPlayersWeather[1] = weather1;
                    Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                    Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                    Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);

                    Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                    WasDropped = true;

                }
                if (weather1.Effect.Contains("S") && NameofSlot == "S")
                {
                    Board.BothPlayersWeather[2] = weather1;
                    Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                    Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                    Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                    Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                    Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);

                    WasDropped = true;
                }

                if (WasDropped)
                {
                    if (Drag.OriginalParent.parent.name == "Player1")
                    {
                        GameManager.player1.Hand.ListOfCards.Remove(weather1);

                    }
                    if (Drag.OriginalParent.parent.name == "Player2")
                    {
                        GameManager.player2.Hand.ListOfCards.Remove(weather1);
                    }

                    if (Drag.OriginalParent.parent.name == "Player1" && GameManager.player2.Pased == false)
                    {
                        GameManager.player1.IsMyturn = false;
                        GameManager.player2.IsMyturn = true;
                        UIMessage.text = $"Turno de {GameManager.player2.Name}";
                    }
                    if (Drag.OriginalParent.parent.name == "Player2" && GameManager.player1.Pased == false)
                    {
                        GameManager.player1.IsMyturn = true;
                        GameManager.player2.IsMyturn = false;
                        UIMessage.text = $"Turno de {GameManager.player1.Name}";
                    }
                    Board.UpdatePoints(GameManager.player1.boardPlayer);
                    Board.UpdatePoints(GameManager.player2.boardPlayer);

                    WasDropped = false;
                }

            }
            else if (Drag.DraggedCard.GetComponent<CardVisual>().Card is BonusCard bonusCard && ((this.transform.parent.name == "Player1" && Drag.OriginalParent.parent.name == "Player1") || (this.transform.parent.name == "Player2" && Drag.OriginalParent.parent.name == "Player2")))
            {
                if (Drag.OriginalParent.parent.name == "Player1")
                {

                    if (bonusCard.Effect.Contains("M") && NameofSlot == "M")
                    {
                        GameManager.player1.boardPlayer.bonus[0] = bonusCard;
                        Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                        Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                        Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                        Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                        Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);

                        Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                        WasDropped = true;
                    }
                    if (bonusCard.Effect.Contains("R") && NameofSlot == "R")
                    {
                        GameManager.player1.boardPlayer.bonus[1] = bonusCard;
                        Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                        Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                        Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                        Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                        Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);

                        Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                        WasDropped = true;
                    }
                    if (bonusCard.Effect.Contains("S") && NameofSlot == "S")
                    {
                        GameManager.player1.boardPlayer.bonus[2] = bonusCard;
                        Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                        Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                        Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                        Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                        Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);

                        Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                        WasDropped = true;
                    }
                    GameManager.player1.Hand.ListOfCards.Remove(bonusCard);

                    if (WasDropped)
                    {
                        if (Drag.OriginalParent.parent.name == "Player1" && GameManager.player2.Pased == false)
                        {
                            GameManager.player1.IsMyturn = false;
                            GameManager.player2.IsMyturn = true;
                            UIMessage.text = $"Turno de {GameManager.player2.Name}";
                        }
                        if (Drag.OriginalParent.parent.name == "Player2" && GameManager.player1.Pased == false)
                        {
                            GameManager.player1.IsMyturn = true;
                            GameManager.player2.IsMyturn = false;
                            UIMessage.text = $"Turno de {GameManager.player1.Name}";
                        }
                        Board.UpdatePoints(GameManager.player1.boardPlayer);
                        Board.UpdatePoints(GameManager.player2.boardPlayer);

                        WasDropped = false;
                    }

                }
                if (Drag.OriginalParent.parent.name == "Player2")
                {

                    if (bonusCard.Effect.Contains("M") && NameofSlot == "M")
                    {
                        GameManager.player2.boardPlayer.bonus[0] = bonusCard;
                        Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                        Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                        Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                        Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                        Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);

                        Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                        WasDropped = true;
                    }
                    if (bonusCard.Effect.Contains("R") && NameofSlot == "R")
                    {
                        GameManager.player2.boardPlayer.bonus[1] = bonusCard;
                        Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                        Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                        Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                        Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                        Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                        Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);

                        WasDropped = true;
                    }
                    if (bonusCard.Effect.Contains("S") && NameofSlot == "S")
                    {
                        GameManager.player2.boardPlayer.bonus[2] = bonusCard;
                        Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
                        Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
                        Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
                        Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
                        Drag.DraggedCard.GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, Drag.DraggedCard.GetComponent<CardVisual>().Card);

                        Drag.DraggedCard.GetComponent<Drag>().enabled = false;
                        WasDropped = true;
                    }
                    GameManager.player2.Hand.ListOfCards.Remove(bonusCard);

                    if (WasDropped)
                    {
                        if (Drag.OriginalParent.parent.name == "Player1" && GameManager.player2.Pased == false)
                        {
                            GameManager.player1.IsMyturn = false;
                            GameManager.player2.IsMyturn = true;
                            UIMessage.text = $"Turno de {GameManager.player2.Name}";
                        }
                        if (Drag.OriginalParent.parent.name == "Player2" && GameManager.player1.Pased == false)
                        {
                            GameManager.player1.IsMyturn = true;
                            GameManager.player2.IsMyturn = false;
                            UIMessage.text = $"Turno de {GameManager.player1.Name}";
                        }
                        Board.UpdatePoints(GameManager.player1.boardPlayer);
                        Board.UpdatePoints(GameManager.player2.boardPlayer);

                        WasDropped = false;
                    }

                }


            }


        }

    }
}

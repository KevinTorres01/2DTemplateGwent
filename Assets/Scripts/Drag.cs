using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject DraggedCard;
    public static Vector3 OriginalPosition;
    public static Transform OriginalParent;
    public void OnBeginDrag(PointerEventData eventData)                               // Guardo las propiedes del drag y hago q la carta c mueva por encima de todo
    {

        DraggedCard = this.gameObject;
        OriginalPosition = this.transform.position;
        OriginalParent = this.transform.parent;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        this.transform.SetParent(transform.root);
        this.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)              // la carta regresa a la mano  en la  ultima posicion
    {
        this.transform.SetParent(OriginalParent);
        this.transform.position = OriginalPosition;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (this.GetComponent<CardVisual>().Card is Clearance card)
        {
            if (GameManager.player1.IsMyturn)
            {
                GameManager.player1.Hand.ListOfCards.Remove(card);
                Weather[] weathers = new Weather[3];
                Board.BothPlayersWeather = weathers;
            }
            if (GameManager.player2.IsMyturn)
            {
                GameManager.player2.Hand.ListOfCards.Remove(card);
                Weather[] weathers = new Weather[3];
                Board.BothPlayersWeather = weathers;
            }
            Destroy(this.gameObject);
            GameManager.gameManager.DestroyWeathers();

            for (int i = 0; i < GameManager.player1.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in GameManager.player1.boardPlayer.UnitCards[i])
                {
                    if (item is SilverCard silverCard)
                    {
                        silverCard.Score = silverCard.PowerPoints;
                    }
                }
            }
            for (int i = 0; i < GameManager.player2.boardPlayer.UnitCards.Length; i++)
            {
                foreach (var item in GameManager.player2.boardPlayer.UnitCards[i])
                {
                    if (item is SilverCard silverCard)
                    {
                        silverCard.Score = silverCard.PowerPoints;
                    }
                }
            }
            Board.UpdatePoints(GameManager.player1.boardPlayer);
            Board.UpdatePoints(GameManager.player2.boardPlayer);
            GameManager.gameManager.ActPointsInFronten();

        }


    }
}

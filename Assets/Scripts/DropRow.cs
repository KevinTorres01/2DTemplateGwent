using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropRow : MonoBehaviour, IDropHandler
{
    public string NameOfRow;
   
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
                    GameManager.player1.Hand.ListOfCards.Remove(unitCard);
                }
                if (NameOfRow == "S")
                {
                    GameManager.player1.boardPlayer.UnitCards[2].Add(unitCard);
                    GameManager.player1.Hand.ListOfCards.Remove(unitCard);
                }
                if (NameOfRow == "R")
                {
                    GameManager.player1.boardPlayer.UnitCards[1].Add(unitCard);
                    GameManager.player1.Hand.ListOfCards.Remove(unitCard);
                }
                Board.UpdatePointsM(GameManager.player1.boardPlayer);

            }
            if (this.transform.parent.name == "Player2")
            {
                if (NameOfRow == "M")
                {
                    GameManager.player2.boardPlayer.UnitCards[0].Add(unitCard);
                    GameManager.player2.Hand.ListOfCards.Remove(unitCard);
                }
                if (NameOfRow == "S")
                {
                    GameManager.player2.boardPlayer.UnitCards[2].Add(unitCard);
                    GameManager.player2.Hand.ListOfCards.Remove(unitCard);
                }
                if (NameOfRow == "R")
                {
                    GameManager.player2.boardPlayer.UnitCards[1].Add(unitCard);
                    GameManager.player2.Hand.ListOfCards.Remove(unitCard);
                }
                Board.UpdatePointsM(GameManager.player2.boardPlayer);

            }
            if (this.transform.parent.name == "Player1")
            {
                GameManager.player1.IsMyturn = false;
                GameManager.player2.IsMyturn = true;
            }
            else 
            {
                GameManager.player1.IsMyturn = true;
                GameManager.player2.IsMyturn = false;
            }
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public string NameofSlot;
    [SerializeField] public TextMeshProUGUI UIMessage;
    public void OnDrop(PointerEventData eventData)
    {
        if (this.transform.childCount == 0 && ((Drag.DraggedCard.GetComponent<CardVisual>().Card is Weather weather && weather.Effect.Contains(NameofSlot)) || (Drag.DraggedCard.GetComponent<CardVisual>().Card is BonusCard bonus && Drag.OriginalParent.parent.name == this.transform.parent.name && bonus.Effect.Contains(NameofSlot))))
        {

            Drag.DraggedCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Drag.DraggedCard.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
            Drag.DraggedCard.transform.position = this.GetComponent<HorizontalLayoutGroup>().transform.position;
            Drag.DraggedCard.transform.rotation = this.GetComponent<HorizontalLayoutGroup>().transform.rotation;
            Drag.DraggedCard.GetComponent<Drag>().enabled = false;

            if (Drag.DraggedCard.GetComponent<CardVisual>().Card is Weather weather1)
            {
                if (weather1.Effect.Contains("M"))
                {
                    Board.BothPlayersWeather[0] = weather1;
                }
                if (weather1.Effect.Contains("R"))
                {
                    Board.BothPlayersWeather[1] = weather1;
                }
                if (weather1.Effect.Contains("S"))
                {
                    Board.BothPlayersWeather[2] = weather1;
                }
                if (Drag.OriginalParent.parent.name == "Player1")
                {
                    GameManager.player1.Hand.ListOfCards.Remove(weather1);

                }
                if (Drag.OriginalParent.parent.name == "Player2")
                {
                    GameManager.player2.Hand.ListOfCards.Remove(weather1);
                }

            }


            if (Drag.OriginalParent.parent.name == "Player1")
            {
                GameManager.player1.IsMyturn = false;
                GameManager.player2.IsMyturn = true;
                UIMessage.text = $"Turno de {GameManager.player2.Name}";
            }
            if (Drag.OriginalParent.parent.name == "Player2")
            {
                GameManager.player1.IsMyturn = true;
                GameManager.player2.IsMyturn = false;
                UIMessage.text = $"Turno de {GameManager.player1.Name}";
            }
        }

    }
}

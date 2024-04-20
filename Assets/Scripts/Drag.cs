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
    public void OnBeginDrag(PointerEventData eventData)
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

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(OriginalParent);
        this.transform.position = OriginalPosition;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    static Vector3 Scale = new Vector3(3.5f, 3.5f, 3.5f);
    static Vector3 Pos = new Vector3(-789f, 0f, 0f);
    GameObject ScaledObject;

    public void OnPointerEnter(PointerEventData eventData)                                   // Escala la carta al pasarle por encima con el mouse
    {
        ScaledObject = Instantiate(gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
        ScaledObject.transform.SetParent(transform.root);
        ScaledObject.transform.localScale = Scale;
        ScaledObject.transform.localPosition = Pos;
    }

    public void OnPointerExit(PointerEventData eventData)               // elimina la instancia de la carta escalada cuando el mouse sale de encima de ella
    {
        Destroy(ScaledObject);
    }
}

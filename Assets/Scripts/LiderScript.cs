using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiderScript : MonoBehaviour
{
    public GameObject Lider;
    void Start()
    {
        if (this.transform.parent.name == "Player1")
        {
            var card = Instantiate(Lider, new Vector3(0, 0, 0), Quaternion.identity);
            card.GetComponent<CardVisual>().ChangeImage(GameManager.player1.Playerdeck.Lider);
            card.GetComponent<CardVisual>().SetPoints(GameManager.player1.Playerdeck.Lider);
            card.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
            card.GetComponent<Drag>().enabled = false;
        }
        if (this.transform.parent.name == "Player2")
        {
            var card = Instantiate(Lider, new Vector3(0, 0, 0), Quaternion.identity);
            card.GetComponent<CardVisual>().ChangeImage(GameManager.player2.Playerdeck.Lider);
            card.GetComponent<CardVisual>().SetPoints(GameManager.player2.Playerdeck.Lider);
            card.transform.SetParent(this.GetComponent<HorizontalLayoutGroup>().transform);
            card.GetComponent<Drag>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

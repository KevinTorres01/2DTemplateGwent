using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassButton : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.player1.IsMyturn == false && this.transform.parent.name == "Player1")
        {
          //  Debug.Log("Boton del jugador 1 turno del jugador 2 desactivando boton 1");
            this.GetComponent<Button>().interactable = false;
            return;
        }
        if (GameManager.player2.IsMyturn == false && this.transform.parent.name == "Player2")
        {
            //Debug.Log("Boton del jugador 2 turno del jugador 1 desactivando boton 2");
            this.GetComponent<Button>().interactable = false;
            return;
        }
        if (GameManager.player1.IsMyturn == true && this.transform.parent.name == "Player1")
        {
            //Debug.Log("Boton del jugador 1 turno del jugador 1 activando boton 1");
            this.GetComponent<Button>().interactable = true;
            return;
        }
        if (GameManager.player2.IsMyturn == true && this.transform.parent.name == "Player2")
        {
            //Debug.Log("Boton del jugador 2 turno del jugador 2 activando boton 2");
            this.GetComponent<Button>().interactable = true;
            return;
        }
    }
}

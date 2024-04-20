using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassButton : MonoBehaviour
{
    void Update()
    {
        if (GameManager.player1.IsMyturn == false && this.transform.parent.name == "Player1")
        {
            this.GetComponent<Button>().interactable = false;
            return;
        }
        if (GameManager.player2.IsMyturn == false && this.transform.parent.name == "Player2")
        {
            this.GetComponent<Button>().interactable = false;
            return;
        }
        if (GameManager.player1.IsMyturn == true && this.transform.parent.name == "Player1")
        {
            this.GetComponent<Button>().interactable = true;
            return;
        }
        if (GameManager.player2.IsMyturn == true && this.transform.parent.name == "Player2")
        {
            this.GetComponent<Button>().interactable = true;
            return;
        }
    }
}

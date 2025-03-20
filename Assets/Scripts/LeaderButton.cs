using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderButton : MonoBehaviour
{
    bool Player1Toched = false;
    bool Player2Touched = false;
    public void TakeLeaderEffect()
    {
        this.transform.GetChild(0).GetComponent<CardVisual>().Card.TakeEffect(GameManager.player1, GameManager.player2, this.transform.GetChild(0).GetComponent<CardVisual>().Card);
        if (GameManager.player1.IsMyturn)
        {
            Player1Toched = true;
            GameManager.player1.IsMyturn = false;
            GameManager.player2.IsMyturn = true;
        }
        else
        {
            GameManager.player2.IsMyturn = false;
            GameManager.player1.IsMyturn = true;
            Player2Touched = true;
        }
    }

    void Update()
    {
        if (this.transform.parent.name == "Player1")
        {
            if (!Player1Toched)
            {
                if (GameManager.player1.IsMyturn)
                    this.GetComponent<Button>().interactable = true;
                else this.GetComponent<Button>().interactable = false;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }

        if (this.transform.parent.name == "Player2")
        {

            if (!Player2Touched)
            {
                if (GameManager.player2.IsMyturn)
                    this.GetComponent<Button>().interactable = true;
                else this.GetComponent<Button>().interactable = false;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
    }
}

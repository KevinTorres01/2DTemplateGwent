using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActPoints : MonoBehaviour
{
    public TextMeshProUGUI points;
    public string row;
   
    void Update()
    {
        if (this.transform.parent.parent.name == "Player1")
        {
            if (row == "M")
            {
                points.text = GameManager.player1.boardPlayer.rowMPoints.ToString();
            }
            if (row == "S")
            {
                points.text = GameManager.player1.boardPlayer.rowSPoints.ToString();
            }
            if (row == "R")
            {
                points.text = GameManager.player1.boardPlayer.rowRPoints.ToString();
            }

        }
        if (this.transform.parent.parent.name == "Player2")
        {
            if (row == "M")
            {
                points.text = GameManager.player2.boardPlayer.rowMPoints.ToString();
            }
            if (row == "S")
            {
                points.text = GameManager.player2.boardPlayer.rowSPoints.ToString();
            }
            if (row == "R")
            {
                points.text = GameManager.player2.boardPlayer.rowRPoints.ToString();
            }

        }
    }
}

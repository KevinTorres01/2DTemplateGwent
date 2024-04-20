using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalPoints : MonoBehaviour
{
    public TextMeshProUGUI Points;
    void Update()
    {
        if (this.transform.parent.parent.name == "Player1")
        {
            Points.text = GameManager.player1.boardPlayer.score.ToString();
        }
        if (this.transform.parent.parent.name == "Player2")
        {
            Points.text = GameManager.player2.boardPlayer.score.ToString();
        }
    }
}

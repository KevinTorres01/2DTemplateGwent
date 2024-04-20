using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI Name;
    
    void Start()
    {
        if (this.transform.parent.name == "Player1")
        {
            Name.text = GameManager.player1.Name;
        }
        if (this.transform.parent.name == "Player2")
        {
             Name.text = GameManager.player2.Name;
        }
    }
}

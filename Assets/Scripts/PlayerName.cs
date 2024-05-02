using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI Name;

    void Start()                                       // Anade el nomre del jugador en la escena de elegir deck que luego se lo pasa como parametro al jugador para mostrarlo en el juego
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

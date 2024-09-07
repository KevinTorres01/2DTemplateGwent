using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class FillFactionOfPlayers : MonoBehaviour
{
    public TextMeshProUGUI factionName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetFactions()
    {
        if (this.transform.parent.name == "VerticalOfP1")
        {
            Debug.Log("Entro al metodo 1");
            GameData.gameData.FillPlayer1Faction(factionName.text);
        }
        if (this.transform.parent.name == "VerticalOfP2")
        {Debug.Log("Entro al metodo 2");

            GameData.gameData.FillPlayer2Faction(factionName.text);
        }
    }
}

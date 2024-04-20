using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetPlayerManager : MonoBehaviour
{
    public TextMeshProUGUI Player1Name;
    public TextMeshProUGUI Player2Name;
    public Button OkButton1;
    public Button OkButton2;

    void Start()
    {
        OkButton1.interactable = false;
        OkButton2.interactable = false;
    }

    void Update()
    {
        if (Player1Name.text.Length > 1 && GameData.Player1Faction != null)
        {
            OkButton1.interactable = true;
        }

        else
            OkButton1.interactable = false;

        if (Player2Name.text.Length > 1 && GameData.Player2Faction != null)
        {
            OkButton2.interactable = true;
        }

        else
            OkButton2.interactable = false;

        if (GameData.Player1Name != null && GameData.Player2Name != null)
        {
            SceneManager.LoadScene("Battlefield");
        }
    }
    public void SetPlayer1Name()
    {
        GameData.FillPlayer1Name(Player1Name.text);
    }
    public void SetPlayer2Name()
    {
        GameData.FillPlayer2Name(Player2Name.text);
    }
}

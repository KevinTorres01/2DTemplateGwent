using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static string Player1Name;
    public static string Player2Name;
    public static string Player1Faction;
    public static string Player2Faction;
    public static GameData gameData;
    void Awake()                           // guardo los datos de la escena de poner el nombre 
    {
        if (gameData == null)
        {
            gameData = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (gameData != this)
            Destroy(gameObject);
    }

    public static void FillPlayer1Name(string name)
    {
        Player1Name = name;
    }
    public static void FillPlayer2Name(string name)
    {
        Player2Name = name;
    }
    public void FillPlayer1Faction(string faction)
    {
        Player1Faction = faction;
    }
    public void FillPlayer2Faction(string faction)
    {
        Player2Faction = faction;
    }

}

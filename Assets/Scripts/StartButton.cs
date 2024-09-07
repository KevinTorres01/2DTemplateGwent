using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void ChangeScene()
    {
        Debug.Log("Entro al start");
        CardCreator.CreateCards();
        GameManager.CreateCompiledCards();
        SceneManager.LoadScene("SetPlayer");
    }
}

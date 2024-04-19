using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassButton : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.player1.IsMyturn == false && this.transform.parent.name == "Player1")
        {
            Debug.Log("El comunismo es pinga");
            this.GetComponent<Button>().interactable = false;
        }
        if (GameManager.player2.IsMyturn == false && this.transform.parent.name == "Player2")
        {
            this.GetComponent<Button>().interactable = false;
        }
        if (GameManager.player1.IsMyturn == true && this.transform.parent.name == "Player1")
        {
            this.GetComponent<Button>().interactable = true;
        }
        if (GameManager.player2.IsMyturn == true && this.transform.parent.name == "Player2")
        {
            this.GetComponent<Button>().interactable = true;
        }
    }
}

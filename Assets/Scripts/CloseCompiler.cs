using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseCompiler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToCompiler()
    {
        SceneManager.LoadScene("TextToCompile");
    }
}

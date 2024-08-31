using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEditor.PackageManager;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.VersionControl;
using System.Threading.Tasks;
using System.IO;

public class CompileButtom : MonoBehaviour
{
    public TextMeshProUGUI text;
    public VerticalLayoutGroup ErrorShow;
    public GameObject ErrorPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public async void Compile()
    {
        try
        {
            Compiler.Compile(text.text.Substring(0, text.text.Length - 1));
            Debug.Log("The code Was compiled");
            string root = "/home/kevin/Subiendo proyecto/2DTemplate/Assets/Text/Text";
            StreamWriter streamWriter = new StreamWriter(root, true);
            streamWriter.Write(text.text.Substring(0, text.text.Length - 1));
            streamWriter.WriteLine();
            streamWriter.Close();
            Debug.Log("The writer has been executed");
        }
        catch (Exception e)
        {
            Debug.Log("The compiler throw Exeption");
            var newMessage = Instantiate(ErrorPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newMessage.transform.SetParent(ErrorShow.transform);
            newMessage.transform.position = ErrorShow.transform.position;
            newMessage.GetComponent<TextMeshProUGUI>().text = "Error : " + e.Message;
            await System.Threading.Tasks.Task.Delay(5000);
            Destroy(newMessage.gameObject);
        }
    }
}

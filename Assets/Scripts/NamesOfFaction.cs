using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NamesOfFaction : MonoBehaviour
{
    public GameObject FactionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        VerticalLayoutGroup verticalLayoutGroup = transform.GetComponent<VerticalLayoutGroup>();
        Debug.Log("El dicc tiene " + DeckCreator.decks.Count + " elementos");
        foreach (var item in DeckCreator.decks.Keys)
        {
            var newFaction = Instantiate(FactionPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            newFaction.transform.SetParent(verticalLayoutGroup.transform);
            newFaction.transform.GetComponent<TextMeshProUGUI>().text = item;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

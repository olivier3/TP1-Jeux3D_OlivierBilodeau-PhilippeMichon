using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionUI : MonoBehaviour
{
    private TextMeshProUGUI textObjetsInteragibles;

    // Start is called before the first frame update
    void Start()
    {
        textObjetsInteragibles = GameObject.FindGameObjectWithTag("UIRamasserObjet").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AfficherMessagePourObjet(string message = "")
    {
        textObjetsInteragibles.text = message;
    }
}

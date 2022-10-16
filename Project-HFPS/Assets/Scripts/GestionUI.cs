using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionUI : MonoBehaviour
{
    private TextMeshProUGUI textObjetsInteragibles;
    private TextMeshProUGUI textChangementArme;

    // Start is called before the first frame update
    void Start()
    {
        textObjetsInteragibles = this.transform.Find("RamasserObjet").gameObject.GetComponent<TextMeshProUGUI>();
        textChangementArme = this.transform.Find("TutorielChangerArme").gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AfficherMessagePourObjet(string message = "")
    {
        textObjetsInteragibles.text = message;
    }

    public void AfficherMessageChangementArme(string message = "")
    {
        textChangementArme.text = message;
    }
}

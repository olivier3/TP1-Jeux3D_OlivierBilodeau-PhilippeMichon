using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionUI : MonoBehaviour
{
    private TextMeshProUGUI textObjetsInteragibles;
    private TextMeshProUGUI textChangementArme;
    private TextMeshProUGUI textFractionsBluePrint;
    private int nbFractionsBluePrint = 0;

    // Start is called before the first frame update
    void Start()
    {
        textObjetsInteragibles = this.transform.Find("RamasserObjet").gameObject.GetComponent<TextMeshProUGUI>();
        textChangementArme = this.transform.Find("TutorielChangerArme").gameObject.GetComponent<TextMeshProUGUI>();
        textFractionsBluePrint = this.transform.Find("FractionsDuBluePrint").gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nbFractionsBluePrint < 8)
        {
            textFractionsBluePrint.text = "Blueprint: " + nbFractionsBluePrint + "/8";
            return;
        }

        textFractionsBluePrint.rectTransform.anchoredPosition = new Vector3(-100,
            textFractionsBluePrint.rectTransform.anchoredPosition.y);
        textFractionsBluePrint.text = "Blueprint complété";
    }

    public void AfficherMessagePourObjet(string message = "")
    {
        textObjetsInteragibles.text = message;
    }

    public void AfficherMessageChangementArme(string message = "")
    {
        textChangementArme.text = message;
    }

    public void PapierRecupere()
    {
        nbFractionsBluePrint++;
    }
}

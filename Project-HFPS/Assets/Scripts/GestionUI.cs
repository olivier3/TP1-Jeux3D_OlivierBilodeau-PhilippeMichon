using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionUI : MonoBehaviour
{
    private TextMeshProUGUI textObjetsInteragibles;
    private TextMeshProUGUI textChangementArme;
    private TextMeshProUGUI textFractionsBluePrint;
    private TextMeshProUGUI textPoints;
    private int nbFractionsBluePrint = 0;
    private long nbPoints = 0;
    private bool cleObtenu = false;

    // Start is called before the first frame update
    void Start()
    {
        textObjetsInteragibles = this.transform.Find("RamasserObjet").gameObject.GetComponent<TextMeshProUGUI>();
        textChangementArme = this.transform.Find("TutorielChangerArme").gameObject.GetComponent<TextMeshProUGUI>();
        textFractionsBluePrint = this.transform.Find("FractionsDuBluePrint").gameObject.GetComponent<TextMeshProUGUI>();
        textPoints = this.transform.Find("Points").gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textPoints.text = "Points: " + nbPoints;

        if (cleObtenu)
        {
            textFractionsBluePrint.text = "Cl� obtenue";
            return;
        }

        if (nbFractionsBluePrint < 8)
        {
            textFractionsBluePrint.text = "Blueprint: " + nbFractionsBluePrint + "/8";
            return;
        }

        textFractionsBluePrint.text = "Blueprint compl�t�";
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

    public int ObtenirNbPapiers()
    {
        return nbFractionsBluePrint;
    }

    public void CreerCle()
    {
        cleObtenu = true;
        nbFractionsBluePrint = 0;
    }

    public bool CleDejaCree()
    {
        return cleObtenu;
    }
}

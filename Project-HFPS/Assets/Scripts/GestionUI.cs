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
    public bool cleObtenu = false;
    private GameObject player;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        textObjetsInteragibles = this.transform.Find("RamasserObjet").gameObject.GetComponent<TextMeshProUGUI>();
        textChangementArme = this.transform.Find("TutorielChangerArme").gameObject.GetComponent<TextMeshProUGUI>();
        textFractionsBluePrint = this.transform.Find("FractionsDuBluePrint").gameObject.GetComponent<TextMeshProUGUI>();
        textPoints = this.transform.Find("Points").gameObject.GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("FPSController");

        Destroy(this.transform.Find("IntroPart1").gameObject, 5);

        yield return new WaitForSeconds(5);

        GameObject introPart2 = this.transform.Find("IntroPart2").gameObject;

        introPart2.SetActive(true);

        Destroy(introPart2, 8);

        yield return new WaitForSeconds(5);

        GameObject introPart3 = this.transform.Find("IntroPart3").gameObject;

        introPart3.SetActive(true);

        Destroy(introPart3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        textPoints.text = "Points: " + player.GetComponent<Points>().GetPoints();

        if (cleObtenu)
        {
            textFractionsBluePrint.text = "Clé obtenue";
            return;
        }

        if (nbFractionsBluePrint < 8)
        {
            textFractionsBluePrint.text = "Blueprint: " + nbFractionsBluePrint + "/8";
            return;
        }

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

    public int ObtenirNbPapiers()
    {
        return nbFractionsBluePrint;
    }

    public long ObtenirNbPoints()
    {
        return player.GetComponent<Points>().GetPoints();
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

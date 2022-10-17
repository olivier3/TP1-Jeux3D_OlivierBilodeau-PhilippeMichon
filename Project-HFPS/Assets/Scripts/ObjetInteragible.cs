using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetInteragible : MonoBehaviour
{
    private bool estAccessible = false;
    private long compteur = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (estAccessible && Input.GetKeyDown(KeyCode.Mouse1))
        {
            GestionUI gestion = GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<GestionUI>();

            GameObject objet = this.gameObject.transform.parent.gameObject;

            if (objet.name == "Portail" &&
                gestion.CleDejaCree() &&
                gestion.ObtenirNbPoints() >= 5000)
            {
                // enlever le message de pickup
                gestion.AfficherMessagePourObjet();
                objet.GetComponent<FinJeu>().Victoire();
                return;
            }

            if (objet.tag == "Arme")
            {
                // enlever le message de pickup
                gestion.AfficherMessagePourObjet();
                objet.transform.GetComponent<Armes>().Ramasser(this.gameObject);
                return;
            }

            if (objet.name == "Table" &&
                !gestion.CleDejaCree() &&
                gestion.ObtenirNbPapiers() >= 8)
            {
                // enlever le message de pickup
                gestion.AfficherMessagePourObjet();
                gestion.CreerCle();
                return;
            }

            if (objet.name.Contains("Clipboard"))
            {
                // enlever le message de pickup
                gestion.AfficherMessagePourObjet();
                gestion.PapierRecupere();
                Destroy(objet);
            }
        }

        if (compteur < 100)
            compteur++;
    }

    private void OnTriggerEnter(Collider collider)
    {
        // compteur pour eviter faux true au debut
        if (collider.transform.tag.Contains("Joueur") && compteur >= 100)
        {
            estAccessible = true;

            GameObject objet = this.gameObject.transform.parent.gameObject;
            GestionUI gestion = GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<GestionUI>();

            if (objet.name == "Portail")
            {
                if (gestion.CleDejaCree() && gestion.ObtenirNbPoints() >= 5000)
                {
                    gestion.AfficherMessagePourObjet("Cliquez droit pour fuir la zone");
                    return;
                }

                gestion.AfficherMessagePourObjet("Il faut une clé et 5000 points pour fuir la zone");
                return;
            }

            if (objet.name == "Table")
            {
                if (gestion.CleDejaCree())
                {
                    gestion.AfficherMessagePourObjet("La clé a déjà été créée");
                    return;
                }

                if (gestion.ObtenirNbPapiers() >= 8)
                {
                    gestion.AfficherMessagePourObjet("Cliquez droit pour créer la clé");
                    return;
                }

                gestion.AfficherMessagePourObjet("Le nombre de fragments du Blueprint est insuffisant");
                return;
            }

            gestion.AfficherMessagePourObjet("Cliquez droit pour ramasser l'objet");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.tag.Contains("Joueur"))
        {
            estAccessible = false;
            GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<GestionUI>().AfficherMessagePourObjet();
        }
    }
}

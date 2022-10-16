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
            // enlever le message de pickup
            GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<GestionUI>().AfficherMessagePourObjet();

            GameObject objet = this.gameObject.transform.parent.gameObject;

            if (objet.tag == "Arme")
            {
                objet.transform.GetComponent<Armes>().Ramasser(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (compteur < 1000)
            compteur++;
    }

    private void OnTriggerEnter(Collider collider)
    {
        // compteur pour eviter faux true au debut
        if (collider.transform.tag.Contains("Joueur") && compteur >= 1000)
        {
            estAccessible = true;
            GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<GestionUI>().AfficherMessagePourObjet("Cliquez droit pour ramasser l'objet");
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

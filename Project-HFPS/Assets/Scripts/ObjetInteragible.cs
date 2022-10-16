using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetInteragible : MonoBehaviour
{
    private bool estAccessible = false;
    private GestionUI gestionnaire;

    // Start is called before the first frame update
    void Start()
    {
        gestionnaire = GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<GestionUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estAccessible && Input.GetKeyDown(KeyCode.Mouse1))
        {
            // enlever le message de pickup
            gestionnaire.AfficherMessagePourObjet();

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
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag.Contains("Joueur"))
        {
            estAccessible = true;
            gestionnaire.AfficherMessagePourObjet("Cliquez droit pour ramasser l'objet");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.tag.Contains("Joueur"))
        {
            estAccessible = false;
            gestionnaire.AfficherMessagePourObjet();
        }
    }
}

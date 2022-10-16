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
            GameObject joueur = GameObject.FindGameObjectWithTag("Joueur");
            Transform cameraJoueur = joueur.transform.GetChild(0);

            GameObject stockageGuns = cameraJoueur.gameObject.transform.GetChild(0).gameObject;

            // desactiver tout les autres guns pour que celui pris soit en main
            foreach (Transform transformGunStocke in stockageGuns.transform)
            {
                transformGunStocke.gameObject.SetActive(false);
            }

            GameObject gun = this.gameObject.transform.parent.gameObject;

            gun.GetComponent<Rigidbody>().useGravity = false;
            gun.GetComponent<CapsuleCollider>().enabled = false;

            gun.transform.parent = cameraJoueur.transform.GetChild(0);

            // setter les coordonnees
            gun.transform.position = new Vector3(stockageGuns.transform.position.x,
                stockageGuns.transform.position.y,
                stockageGuns.transform.position.z);

            // reset rotation
            // localRotation au lieu de rotation pour ne pas ignorer la rotation du parent
            gun.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

            // enlever le message de pickup
            gestionnaire.AfficherMessagePourObjet();

            gun.GetComponent<Armes>().fpCamera = cameraJoueur.gameObject.GetComponent<Camera>();
            gun.GetComponent<Armes>().enabled = true;

            // pour desactiver le script
            this.enabled = false;
        }
    }

    /*private void OnTriggerStay(Collider collider)
    {
        if (collider.transform.tag.Contains("Joueur"))
        {
            estAccessible = true;
            Debug.Log(estAccessible.ToString());
        }
        else
        {
            estAccessible = false;
            Debug.Log(estAccessible.ToString());
        }
    }*/

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
            Debug.Log(estAccessible.ToString());
            gestionnaire.AfficherMessagePourObjet();
        }
    }
}

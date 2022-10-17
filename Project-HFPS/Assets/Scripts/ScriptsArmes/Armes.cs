using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armes : MonoBehaviour
{
    public Camera fpCamera;
    public float distance = 100;
    public int degats = 50;
    public GameObject animationTir = null;
    public int multiplicateurDommageTete = 10;
    public bool automatique = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetButton("Fire1"));
        if (Input.GetButtonDown("Fire1"))
        {
            Tirer();

            this.gameObject.GetComponent<AudioSource>().Play();

            animationTir.GetComponent<ParticleSystem>().Play();
        }
        else if (automatique && Input.GetButton("Fire1"))
        {
            Tirer();
        }

        if (automatique && Input.GetButtonUp("Fire1"))
        {
            this.gameObject.GetComponent<AudioSource>().Stop();

            if (animationTir != null)
            {
                animationTir.gameObject.GetComponent<ParticleSystem>().Stop();
            }
        }
    }

    private void Tirer()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, distance))
        {
            Debug.Log("J'ai tiré sur cet objet : " + hit.transform.name);

            if (hit.transform.tag == "Ennemi" || hit.transform.tag == "EnnemiTete")
            {
                SanteEnnemi target;
                int degatsInfliges = degats;

                if (hit.transform.tag == "Ennemi")
                {
                    target = hit.transform.GetComponent<SanteEnnemi>();
                }
                else
                {
                    target = hit.transform.parent.GetComponent<SanteEnnemi>();
                    degatsInfliges *= multiplicateurDommageTete;
                }


                if (target != null)
                    target.Blesser(degatsInfliges);
            }
        }
    }

    public void Ramasser(GameObject hitboxRamassage)
    {
        GameObject joueur = GameObject.FindGameObjectWithTag("Joueur");
        Transform cameraJoueur = joueur.transform.GetChild(0);

        GameObject stockageGuns = cameraJoueur.gameObject.transform.GetChild(0).gameObject;

        // desactiver tout les autres guns pour que celui pris soit en main
        foreach (Transform transformGunStocke in stockageGuns.transform)
        {
            transformGunStocke.gameObject.SetActive(false);
        }

        GameObject gun = this.gameObject;

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

        gun.GetComponent<Armes>().fpCamera = cameraJoueur.gameObject.GetComponent<Camera>();
        gun.GetComponent<Armes>().enabled = true;

        // pour desactiver le script
        hitboxRamassage.GetComponent<ObjetInteragible>().enabled = false;

        GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<GestionUI>().AfficherMessageChangementArme("Pour changer d'arme: \"G\"");
    }
}

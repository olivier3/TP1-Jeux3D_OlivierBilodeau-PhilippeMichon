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
                //Ennemi target;
                int degatsInfliges = degats;

                if (hit.transform.tag == "Ennemi")
                {
                    //target = hit.transform.GetComponent<Ennemi>();
                }
                else
                {
                    //target = hit.transform.parent.GetComponent<Ennemi>();
                    degatsInfliges *= multiplicateurDommageTete;
                }


                //if (target != null)
                //target.Blesser(degatsInfliges);
            }
        }
    }
}

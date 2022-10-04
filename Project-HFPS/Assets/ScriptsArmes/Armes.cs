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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Tirer();
        }
    }

    private void Tirer()
    {
        RaycastHit hit;

        this.gameObject.GetComponent<AudioSource>().Play();

        if (animationTir != null)
        {
            animationTir.GetComponent<ParticleSystem>().Play();
        }

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

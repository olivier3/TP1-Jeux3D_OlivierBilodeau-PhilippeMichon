using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueZombie : MonoBehaviour
{
    Transform victime;
    private SanteJoueur santeJoueur;
    private int dommage = 15;

    // Start is called before the first frame update
    void Start()
    {
        victime = GameObject.FindGameObjectWithTag("Joueur").transform;
        santeJoueur = victime.GetComponent<SanteJoueur>();
    }

    public void AttaqueEvent()
    {
        if (victime != null && santeJoueur.sante > 0)
        {
            santeJoueur.Blesser(dommage);
        }
    }

}

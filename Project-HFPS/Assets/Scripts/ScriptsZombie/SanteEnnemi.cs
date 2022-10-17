using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanteEnnemi : MonoBehaviour
{
    Animator animator;
    GameObject gestion;
    GameObject player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gestion = GameObject.Find("GestionZombies");
        player = GameObject.Find("FPSController");
    }

    public int sante = 100;

    public void Blesser(int dommage)
    {
        sante -= dommage;

        if (sante <= 0)
        {
            Mourir();
        }
    }

    public void Mourir()
    {
        animator.SetBool("EstMort", true);
        GetComponent<ZombieMouvement>().enabled = false;
        Invoke("Detruire", 5);
    }

    public void Detruire()
    {
        gestion.GetComponent<ZombiesSpawn>().SpawnZombie();
        gestion.GetComponent<ZombiesSpawn>().SpawnZombie();
        player.GetComponent<Points>().AddPoint();
        Destroy(gameObject);
    }
}

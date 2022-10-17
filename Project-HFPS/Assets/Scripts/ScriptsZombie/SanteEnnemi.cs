using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanteEnnemi : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public int sante = 100;

    public void Blesser(int dommage)
    {
        sante -= dommage;

        if (sante <= 0)
        {
            Destroy(gameObject);
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
        Destroy(gameObject);
    }
}

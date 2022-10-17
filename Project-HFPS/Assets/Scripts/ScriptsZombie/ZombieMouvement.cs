using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMouvement : MonoBehaviour
{
    Animator animator;
    Transform victime;                      //Représente de FPS Controller.
    public int distancePoursuite = 200;      //Distance maximum à partir de laquelle l'ennemi nous poursuit.
    public int distanceAttaque = 2;         //Distance maximum à partir de laquelle l'ennemi nous attaque.
    NavMeshAgent navMeshAgent;              //Nous servira à définir le comportement de l'ennemi.
    float distanceVictime = Mathf.Infinity; //Distance entre le FPS Controller et l'ennmi.

    void Start()
    {
        victime = GameObject.FindGameObjectWithTag("Joueur").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        distanceVictime = Vector3.Distance(victime.position, transform.position);

        if (distanceVictime <= distanceAttaque)
        {
            animator.SetBool("Attaque", true);
        }
        else if (distanceVictime <= distancePoursuite)
        {
            navMeshAgent.SetDestination(victime.position);
            animator.SetBool("Attaque", false);

        }
        else
        {
            navMeshAgent.ResetPath();
            animator.SetBool("Attaque", false);
            animator.SetBool("EnnemiTrouve", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distancePoursuite);
    }

}

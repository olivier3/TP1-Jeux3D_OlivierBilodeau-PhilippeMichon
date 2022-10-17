using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanteJoueur : MonoBehaviour
{
    public Image imgHit; 
    public int sante = 100;
    private GameObject portal;

    private void Start()
    {
        portal = GameObject.Find("Portail");
    }

    private void Update()
    {
        if (imgHit != null && imgHit.color.a > 0 && sante > 0)
        {
            var couleur = imgHit.color;
            couleur.a -= 0.1f;
            imgHit.color = couleur;
        }

    }

    public void Blesser(int dommage)
    {
        sante -= dommage;

        var couleur = imgHit.color;
        couleur.a = 0.8f;
        imgHit.color = couleur;


        if (sante <= 0)
            Mourir();
    }

    private void Mourir()
    {
        //On recharge la scène lorsque l'on meurt.	
        portal.GetComponent<FinJeu>().Defaite();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerArme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            prochaineArme();
        }
    }

    void prochaineArme()
    {
        GameObject armes = this.transform.GetChild(0).gameObject;

        int nbArmes = armes.transform.childCount;
        int compteur = 0;

        foreach (Transform enfant in armes.transform)
        {
            compteur++;

            if (enfant.gameObject.activeSelf == true)
            {
                enfant.gameObject.SetActive(false);
                break;
            }
        }

        if (compteur >= nbArmes)
        {
            activerArme(armes);
            return;
        }

        activerArme(armes, compteur);
    }

    private void activerArme(GameObject armes, int numeroArme = 0)
    {
        armes.transform.GetChild(numeroArme).gameObject.SetActive(true);
        armes.transform.GetChild(numeroArme).gameObject.transform.Find("hitbox_ramassage").gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class FinJeu : MonoBehaviour
{
    public TextMeshProUGUI textResultat;
    public Button boutonResultat;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        GameObject joueur = GameObject.FindGameObjectWithTag("Joueur");
        joueur.GetComponent<FirstPersonController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Victoire()
    {
        Pause();
        textResultat.text = "Vous avez réussi à vous enfuir. Bravo!";
        boutonResultat.gameObject.SetActive(true);
    }

    public void Defaite()
    {
        Pause();
        textResultat.text = "Vous êtes mort";
        boutonResultat.gameObject.SetActive(true);
    }

    public void Recommencer()
    {
        Scene sceneActuelle = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneActuelle.name);
    }

    public void Pause()
    {
        // ne pas tourner la camera
        GameObject joueur = GameObject.FindGameObjectWithTag("Joueur");
        joueur.GetComponent<FirstPersonController>().enabled = false;

        // pouvoir utiliser la souris
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // mettre en pause la majorite des choses
        Time.timeScale = 0f;

        // arreter les effets sonores
        AudioListener.pause = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorZone : MonoBehaviour
{
    public AudioSource audioSource;
    private bool played = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!played)
        {
            played = true;
            audioSource.Play();
            Destroy(this.gameObject, 6);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiesSpawn : MonoBehaviour
{
    private GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.Find("Zombie");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void SpawnZombie()
    {
        GameObject clone = Instantiate(zombie);

        (int x, int z)[] coords = { (100, 146), (165, 20), (63, 20) };

        int indexCoords = Random.Range(0, 3);

        clone.transform.position = new Vector3(coords[indexCoords].x, 2, coords[indexCoords].z);

        clone.GetComponent<Rigidbody>().useGravity = true;

        clone.GetComponent<NavMeshAgent>().enabled = true;

        clone.GetComponent<ZombieMouvement>().enabled = true;

    }
}

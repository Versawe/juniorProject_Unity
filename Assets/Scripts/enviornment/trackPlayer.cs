using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackPlayer : MonoBehaviour
    // This script has the envoirment track te player so it will spawn another block
{
    public GameObject player;

    public Transform thisObject;

    public GameObject nextObject;

    public Transform spawnPoint;

    public Transform triggerSpawnPoint;
    public Transform triggerBoxCollider;

    private float spawnLimit = 0;

    //BoxCollider bc;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("carPrefabCTA"))
        {
            player = GameObject.Find("carPrefabCTA");
        }
        //bc = GetComponent<BoxCollider>();
        //bc.enabled = false;
    }

    // Update is called once per frame
    // Need to start player near the middle of the block to spawn on back side
    void Update()
    {
        if (GameObject.Find("carPrefabCTA"))
        {
            player = GameObject.Find("carPrefabCTA");
        }

        if (player.transform.position.z > triggerSpawnPoint.position.z)
        {
            spawnLimit += 1;
        }

        if (spawnLimit > 0 && spawnLimit < 2)
        {
            Instantiate(nextObject, spawnPoint.position, spawnPoint.rotation);
            //print("spawned");
        }
        if (player.transform.position.z > thisObject.position.z + 300)
        {
            Destroy(gameObject);
            //print("boom");
        }

        /*if (player.transform.position.z > triggerBoxCollider.position.z + backToOrigin.distanceToOrigin)
        {
            bc.enabled = true;
        }
        */


        //print(spawnLimit);
    }
}

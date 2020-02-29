using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackPlayer : MonoBehaviour
{
    GameObject player;

    public Transform thisObject;

    public GameObject nextObject;

    public Transform spawnPoint;

    public Transform triggerSpawnPoint;
    public Transform triggerBoxCollider;

    private float spawnLimit = 0;

    BoxCollider bc;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        bc.enabled = false;

        if (GameObject.Find("carBox"))
        {
            player = GameObject.Find("carBox");
        }

    }

    // Update is called once per frame
    // Need to start player near the middle of the block to spawn on back side
    void Update()
    {
        if (player.transform.position.z > triggerSpawnPoint.position.z)
        {
            spawnLimit += 1;
        }

        if (spawnLimit > 0 && spawnLimit < 2)
        {
            Instantiate(nextObject, spawnPoint.position, spawnPoint.rotation);
            print("spawned");
        }
        if (player.transform.position.z > thisObject.position.z + 300)
        {
            Destroy(gameObject);
            print("boom");
        }

        if (player.transform.position.z > triggerBoxCollider.position.z)
        {
            bc.enabled = true;
        }

        //print(spawnLimit);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackPlayer : MonoBehaviour
{
    GameObject player;

    public Transform thisObject;

    public GameObject nextObject;

    public Transform spawnPoint;

    public Transform spawnPointBack;

    private float spawnLimit = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("carBox"))
        {
            player = GameObject.Find("carBox");
        }
    }

    // Update is called once per frame
    // Need to start player near the middle of the block to spawn on back side
    void Update()
    {
        if (player.transform.position.z > thisObject.position.z - 20 && player.transform.position.z < thisObject.position.z + 20)
        {
            spawnLimit += 1;
        }
        else
        {
            spawnLimit = 0;
        }

        if (spawnLimit > 0 && spawnLimit < 2)
        {
            Instantiate(nextObject, spawnPoint.position, spawnPoint.rotation);
            Instantiate(nextObject, spawnPointBack.position, spawnPointBack.rotation);
            print("spawned");
        }
        if (player.transform.position.z > thisObject.position.z + 350)
        {
            Destroy(gameObject);
            print("boom");
        }
        if (player.transform.position.z < thisObject.position.z - 350)
        {
            Destroy(gameObject);
            print("boom");
        }

        //print(spawnLimit);
    }
}

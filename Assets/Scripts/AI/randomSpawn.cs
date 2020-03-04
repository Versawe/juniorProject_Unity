using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    GameObject playerCar;
    public GameObject spawnCar;
    public Transform spawnLoc;

    private float spawnTimer = 0;

    private float willSpawnNum;

    private bool willSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("carBox"))
        {
            playerCar = GameObject.Find("carBox");
        }

        willSpawnNum = Random.Range(0,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCar.transform.position.z > spawnLoc.position.z)
        {
            if (willSpawnNum <= 2)
            {
                willSpawn = false;
            }
            if (willSpawnNum >= 3)
            {
                willSpawn = true;
            }

            if (willSpawn)
            {
                spawnTimer += 1;
            }
            if (spawnTimer > 0 && spawnTimer <= 1)
            {
                Instantiate(spawnCar, transform.position, transform.rotation);
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAI : MonoBehaviour
{
    GameObject playerCar;
    public GameObject spawnCar;
    public Transform spawnLoc;

    private float spawnTimer = 0;

    private float willSpawnNum;

    private bool willSpawn;

    private float delay;
    private float delayReset;
    private bool justSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
        playerCar = GameObject.Find("carPrefabCTA");
        

        willSpawnNum = Random.Range(1, 25);
    }

    // Update is called once per frame
    void Update()
    {

        if (safteyFeature.crossTrafficTrigger) 
        {
            if (spawnLoc.gameObject.name == "aiSpawner")
            {
                if (playerCar.transform.position.z > spawnLoc.position.z)
                {
                    if (willSpawnNum <= 8)
                    {
                        willSpawn = false;
                        delayReset = Random.Range(4, 9);
                        justSpawned = true;
                    }
                    if (willSpawnNum > 8)
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
                        justSpawned = true;
                        delayReset = Random.Range(4, 9);
                    }
                }
            }
            if (spawnLoc.gameObject.name == "aiSpawnerFar")
            {
                if (playerCar.transform.position.z < spawnLoc.position.z)
                {
                    if (willSpawnNum <= 8)
                    {
                        willSpawn = false;
                        delayReset = Random.Range(4, 9);
                        justSpawned = true;
                    }
                    if (willSpawnNum > 8)
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
                        justSpawned = true;
                        delayReset = Random.Range(4, 9);
                    }
                }
            }

            if (justSpawned)
            {
                delay += 1 * Time.deltaTime;
                if (delay >= delayReset)
                {
                    willSpawn = false;
                    spawnTimer = 0;
                    delay = 0;
                    delayReset = 0;
                    justSpawned = false;
                    willSpawnNum = Random.Range(1, 25);
                }
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToOrigin : MonoBehaviour
{

    public GameObject player;

    public GameObject newPrefabSpawn;

    public GameObject origin;

    public GameObject gyroDude;

    private float spawnLimit = 0;
    public static bool originSpawn = false;

    public static float distanceToOrigin = 1100;

    // Start is called before the first frame update
    void Start()
    {
        originSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= distanceToOrigin) 
        {
            originSpawn = true;
            //print("oh shat");
           
        }
        if (originSpawn) 
        {
            spawnLimit += 1;
        }
        if (spawnLimit > 0 && spawnLimit < 2)
        {
            //Instantiate(newPrefabSpawn, origin.transform.position, origin.transform.rotation);
            //transform.position = origin.transform.position;
            Vector3 pos = transform.position;

            pos.z += -distanceToOrigin+100;

            transform.position = pos;

            originSpawn = false;
            spawnLimit = 0;

        }

        if (gyroOff.boolBro)
        {
            gyroDude.GetComponent<followGyro>().enabled = false;
        }
        else
        {
            gyroDude.GetComponent<followGyro>().enabled = true;
        }
    }
}

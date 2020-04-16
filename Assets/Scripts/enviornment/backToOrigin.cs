using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToOrigin : MonoBehaviour
{

    public GameObject player;

    public GameObject newPrefabSpawn;

    public GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= 500) 
        {
            player.transform.position.z = origin.transform.position.z;
        }
    }
}

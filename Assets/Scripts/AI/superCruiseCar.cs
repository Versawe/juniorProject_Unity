using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superCruiseCar : MonoBehaviour
{
    public Transform thisCar;

    GameObject playerCar;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("carBox"))
        {
            playerCar = GameObject.Find("carBox");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCar.transform.position.z > thisCar.position.z + 400)
        {
            Destroy(gameObject);
        }
        if (playerCar.transform.position.z < thisCar.position.z - 400)
        {
            Destroy(gameObject);
        }
    }
}

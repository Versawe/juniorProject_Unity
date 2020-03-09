using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superCruiseCar : MonoBehaviour
{
    public Transform thisCar;

    GameObject playerCar;

    private float speed;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (GameObject.Find("carBox"))
        {
            playerCar = GameObject.Find("carBox");
        }

        speed = Random.Range(490, 590);

    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = transform.forward * speed * Time.deltaTime;

        if (playerCar.transform.position.z > thisCar.position.z + 400)
        {
            Destroy(gameObject);
        }
        if (playerCar.transform.position.z < thisCar.position.z - 400)
        {
            Destroy(gameObject);
        }

        if (playerCar.transform.position.x < + thisCar.position.x + 1.8f && playerCar.transform.position.x > thisCar.position.x - 1.8f)
        {
            if (playerCar.transform.position.z < +thisCar.position.z + 1.8f && playerCar.transform.position.z > thisCar.position.z - 1.8f)
            {
                if (playerCar.transform.position.x > thisCar.position.x)
                {
                    //print("bruh RIGHT");
                    rotateWheel.superRightTurn = true;
                    //rotateWheel.superLeftTurn = false;
                }
                if (playerCar.transform.position.x < thisCar.position.x)
                {
                    //print("bruh LEFT");
                    //rotateWheel.superRightTurn = false;
                    rotateWheel.superLeftTurn = true;
                }
            }

        }

    }

}

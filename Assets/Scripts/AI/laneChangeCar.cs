using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laneChangeCar : MonoBehaviour
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

        speed = Random.Range(250, 380);

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;

        if (playerCar.transform.position.z > thisCar.position.z + 400)
        {
            Destroy(gameObject);
        }
        if (playerCar.transform.position.z < thisCar.position.z - 400)
        {
            Destroy(gameObject);
        }

        if (playerCar.transform.position.x < + thisCar.position.x + 2.1f && playerCar.transform.position.x > thisCar.position.x - 2.1f)
        {
            if (playerCar.transform.position.z < +thisCar.position.z + 2.7f && playerCar.transform.position.z > thisCar.position.z - 2.7f)
            {
                if (playerCar.transform.position.x > thisCar.position.x)
                {
                    rotateWheel.laneRightTurn = true;
                }
                if (playerCar.transform.position.x < thisCar.position.x)
                {
                    rotateWheel.laneLeftTurn = true;
                }
            }

        }

    }

}

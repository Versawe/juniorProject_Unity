using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    private float speed = 0;
    private float maxSpeed = 450;
    public static bool movingForward = false;
    public static bool touchedFirstGas = false;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        movingForward = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (movingForward)
        {
            speed += 100 * Time.deltaTime;
        }
        if (!movingForward)
        {
            speed += -20 * Time.deltaTime;
        }
        if (speed <= 0)
        {
            speed = 0;
        }
        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }

        rb.velocity = transform.forward * speed * Time.deltaTime;

        if (rotateWheel.turnLimit <= -2.5f)
        {

        }
        if (rotateWheel.turnLimit >= 2.5f)
        {

        }

        //print(touchedFirstGas);
    }

    public void OnGasDown()
    {
        movingForward = true;
        if (Input.touchCount == 1)
        {
            touchedFirstGas = true;
        }
        if (Input.touchCount == 2)
        {
            touchedFirstGas = false;
        }
    }

    public void OnGasUp()
    {
        movingForward = false;
        touchedFirstGas = false;
    }
}

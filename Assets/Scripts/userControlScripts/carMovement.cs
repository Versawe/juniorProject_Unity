using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public static float speed = 0;
    public static float reverseSpeed = 0;
    private float reverseMaxSpeed = 100;
    private float maxSpeed = 390; //for expressWay = ?
    public bool movingForward = false;
    public bool movingBackwards = false;
    public bool brakePressing = false;

    Vector2 touchPoint;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        movingForward = false;
        speed = 0;
        reverseSpeed = 0;
        rb = GetComponent<Rigidbody>();

        if (safteyFeature.isSuperCruise)
        {
            maxSpeed = 800;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Physics.IgnoreLayerCollision(8,9);

        if (speed <= 0)
        {
            speed = 0;
        }
        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
        if (movingForward && !gearShifterScript.inPark && !gearShifterScript.inReverse)
        {
            speed += 105 * Time.deltaTime;
        }
        if (!movingForward && speed > 0)
        {
            speed += -40 * Time.deltaTime;
        }

        if (reverseSpeed <= 0)
        {
            reverseSpeed = 0;
        }
        if (reverseSpeed >= reverseMaxSpeed)
        {
            reverseSpeed = reverseMaxSpeed;
        }
        if (movingBackwards && !gearShifterScript.inPark && !gearShifterScript.inDrive)
        {
            reverseSpeed += 80 * Time.deltaTime;
        }
        if (!movingBackwards && reverseSpeed > 0)
        {
            reverseSpeed += -58 * Time.deltaTime;
        }

        if (brakePressing && !gearShifterScript.inPark && !gearShifterScript.inReverse)
        {
            speed += -85 * Time.deltaTime;
        }

        if (gearShifterScript.inDrive)
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        if (gearShifterScript.inReverse)
        {
            rb.velocity = -transform.forward * reverseSpeed * Time.deltaTime;
        }

        if (speed > 0)
        {
            transform.Rotate(0, rotateWheel.turnLimit * 23 * Time.deltaTime, 0);
        }
        if (reverseSpeed > 0)
        {
            transform.Rotate(0, -rotateWheel.turnLimit * 23 * Time.deltaTime, 0);
        }

        foreach (Touch touch in Input.touches)
        {

            if (touch.position.x > Screen.width/2)
            {
                
                touchPoint = Camera.main.ScreenToViewportPoint(touch.position);

            }

        }

        //print(speed);
    }

    public void OnGasDown()
    {
        if (gearShifterScript.inDrive)
        {
            movingForward = true;
            movingBackwards = false;
        }
        if (gearShifterScript.inReverse)
        {
            movingBackwards = true;
            movingForward = false;
        }
        if (gearShifterScript.inPark)
        {
            movingBackwards = false;
            movingForward = false;
        }
    }

    public void OnGasUp()
    {
        movingForward = false;
        movingBackwards = false;
    }

    public void OnBrakeDown()
    {
        brakePressing = true;
    }

    public void OnBrakeUp()
    {
        brakePressing = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public static float speed = 0;
    public static float reverseSpeed = 0;
    private float reverseMaxSpeed = 500;
    private float maxSpeed = 1550; //for expressWay = 900
    public bool movingForward = false;
    public bool movingBackwards = false;
    public bool brakePressing = false;

    public static float carRotationX;
    public static float carRotationY;

    Vector2 touchPoint;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        movingForward = false;
        speed = 0;
        reverseSpeed = 0;
        rb = GetComponent<Rigidbody>();

        //changes max speed based on level
        if (safteyFeature.isSuperCruise)
        {
            maxSpeed = 2500;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Physics.IgnoreLayerCollision(8,9);

        // speed/acceleration mechanic
        if (speed <= 0)
        {
            speed = 0;
        }
        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
        if (movingForward && !gearShifterScript.inPark && !gearShifterScript.inReverse && !superCruise.superCruiseActive)
        {
            speed += 425 * Time.deltaTime;
        }
        if (!movingForward && speed > 0 && !superCruise.superCruiseActive)
        {
            speed += -175 * Time.deltaTime;
        }

        //reverse speed mechanic
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
            reverseSpeed += 425 * Time.deltaTime;
        }
        if (!movingBackwards && reverseSpeed > 0)
        {
            reverseSpeed += -175 * Time.deltaTime;
        }

        // braking mechanic
        if (brakePressing && !gearShifterScript.inPark && !gearShifterScript.inReverse && speed > 0)
        {
            speed += -600 * Time.deltaTime;
        }

        //determines which direction user moves on reverse vs drive
        if (gearShifterScript.inDrive)
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        if (gearShifterScript.inReverse)
        {
            rb.velocity = -transform.forward * reverseSpeed * Time.deltaTime;
        }

        //rotates car only if moving forward (like real car)
        if (speed > 0)
        {
            transform.Rotate(0, rotateWheel.turnLimit * 23 * Time.deltaTime, 0);
        }
        if (reverseSpeed > 0)
        {
            transform.Rotate(0, -rotateWheel.turnLimit * 23 * Time.deltaTime, 0);
        }

        //reads touch input only on right side of the screen (to not pay attention to wheel input)
        foreach (Touch touch in Input.touches)
        {

            if (touch.position.x > Screen.width/2)
            {
                
                touchPoint = Camera.main.ScreenToViewportPoint(touch.position);

            }

        }

        carRotationX = transform.localEulerAngles.x;
        carRotationY = transform.localEulerAngles.y;

        //print(speed);
    }

    public void OnGasDown()
    {
        //run if holding gas pedal
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
        //run if release from gas pedal
        movingForward = false;
        movingBackwards = false;
    }

    public void OnBrakeDown()
    {
        //run if holding brake pedal
        brakePressing = true;
    }

    public void OnBrakeUp()
    {
        //run if release from brake pedal
        brakePressing = false;
    }
}

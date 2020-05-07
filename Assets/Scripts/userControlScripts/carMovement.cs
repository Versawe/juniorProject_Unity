using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public static float speed = 0;
    public static float reverseSpeed = 0;
    private float reverseMaxSpeed = 400;
    private float maxSpeed = 1100;
    public bool movingForward = false;
    public bool movingBackwards = false;
    public static bool brakePressing = false;
    private static float rotationActual;
    private float descaler;
    private int lanePortion;
    private int lanePortionLast;

    public Transform targetLane1;
    public Transform targetLane2;
    public Transform targetLane3;
    public Transform targetLane4;

    public Transform forwardVectorAdjust;

    
    private Vector3 point1;
    private Vector3 point2;
    private Vector3 point3;
    private Vector3 point4;

    public float distanceBuffer;
    private Vector3 targetPosition;
    private Vector3 carPosition;
    private Vector3 carPositionLast;
    private float progress;

    private float zLast;
    private float zCurrent;
    private float zDisPerFrame;

    private Quaternion currentRotation;
    private Quaternion lastRotation;
    private Quaternion rotationChange;

    private bool recordedTargetPosition = false;
    
    Vector2 touchPoint;

    Rigidbody rb;
    // Start is called before the first frame update

    void Start()
    {
        movingForward = false;
        brakePressing = false;
        speed = 0;
        reverseSpeed = 0;
        rb = GetComponent<Rigidbody>();

        //changes max speed based on level
        if (safteyFeature.isSuperCruise)
        {
            maxSpeed = 1800;
        }

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics.IgnoreLayerCollision(8,9);

        zLast = zCurrent;
        zCurrent = transform.position.z;
        zDisPerFrame = zCurrent - zLast;

        lastRotation = currentRotation;
        currentRotation = Quaternion.LookRotation(carPosition - carPositionLast, Vector3.up);


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
            speed += 300 * Time.deltaTime;
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
            reverseSpeed += 200 * Time.deltaTime;
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
        if (brakePressing && !gearShifterScript.inPark && !gearShifterScript.inDrive && reverseSpeed > 0)
        {
            reverseSpeed += -850 * Time.deltaTime;
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
            transform.Rotate(0, rotateWheelUpdated.turnLimit, 0);
        }
        if (reverseSpeed > 0)
        {
            transform.Rotate(0, -rotateWheelUpdated.turnLimit, 0);
        }

        //reads touch input only on right side of the screen (to not pay attention to wheel input)
        foreach (Touch touch in Input.touches)
        {

            if (touch.position.x > Screen.width/2)
            {
                
                touchPoint = Camera.main.ScreenToViewportPoint(touch.position);

            }

        }

        carPositionLast = carPosition;

        if(!superCruise.superCruiseActive)
        {
            carPosition = transform.position;
        }

        if (superCruise.superCruiseActive)
        {
            /*
            Vector3 lane = ClosestLane();

            if (transform.position.x > (lane.x + .2f) + ((transform.position.x - lane.x) / 5))
            {
                rotationActual = (transform.position.x - (lane.x + .2f)) * (10 / descaler);
                descaledOnce = true;
            }
            if (transform.position.x < (lane.x - .2f) - ((transform.position.x - lane.x) / 5))
            {
                rotationActual = (transform.position.x - (lane.x)) * 10;
                descaledOnce = true;
            }
            else
            {
                if(descaledOnce == true)
                {
                    descaler += 1;
                    descaledOnce = false;
                }
                lanePortion = 0;
            }
            */
            
            if(recordedTargetPosition == false)
            {
                targetPosition = new Vector3(ClosestLane().x, transform.position.y, transform.position.z + distanceBuffer);
                point1 = transform.position;
                point2 = new Vector3(forwardVectorAdjust.transform.position.x, transform.position.y, forwardVectorAdjust.transform.position.z);
                point3 = new Vector3(targetPosition.x, transform.position.y, transform.position.z + ((targetPosition.z - forwardVectorAdjust.transform.position.z) * (2f/3f)));
                point4 = targetPosition;
                progress = 0;
                recordedTargetPosition = true;
            }

            progress += zDisPerFrame / (point4.z - point1.z);
            
            if (progress <= 1)
            {
                //previous to current frame rotation
                carPosition = CubicCurve(point1, point2, point3, point4, progress);
                //rotationChange = currentRotation * Quaternion.Inverse(lastRotation);
                transform.rotation = currentRotation;
                rotationActual = currentRotation.y / .005f;
            } else
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
        
        if(!superCruise.superCruiseActive)
        {
            //descaler = 1;
            recordedTargetPosition = false;
        }
    }

    public static float getSuperCruzeRotation()
    {
        return rotationActual;
    }

    private Vector3 ClosestLane()
    {
        float distance;
        float smallestDistance = 4;
        float furthestDistance = 4;
        Vector3 closestVector = Vector3.zero;

        distance = transform.position.x - targetLane1.transform.position.x;
        if (Mathf.Abs(distance) < Mathf.Abs(smallestDistance))
        {
            smallestDistance = distance;
            closestVector = targetLane1.transform.position;
        }
        distance = transform.position.x - targetLane2.transform.position.x;
        if (Mathf.Abs(distance) < Mathf.Abs(smallestDistance))
        {
            smallestDistance = distance;
            closestVector = targetLane2.transform.position;
        }
        distance = transform.position.x - targetLane3.transform.position.x;
        if (Mathf.Abs(distance) < Mathf.Abs(smallestDistance))
        {
            smallestDistance = distance;
            closestVector = targetLane3.transform.position;
        }
        distance = transform.position.x - targetLane4.transform.position.x;
        if (Mathf.Abs(distance) < Mathf.Abs(smallestDistance))
        {
            smallestDistance = distance;
            closestVector = targetLane4.transform.position;
        }
        if(Mathf.Abs(smallestDistance) >= Mathf.Abs(furthestDistance))
        {
            closestVector = transform.position;
        }

        return closestVector;
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return a + (b - a) * t;
    }
    public static Vector3 QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 p0 = Lerp(a, b, t);
        Vector3 p1 = Lerp(b, c, t);
        return Lerp(p0, p1, t);
    }
    public static Vector3 CubicCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 p0 = QuadraticCurve(a, b, c, t);
        Vector3 p1 = QuadraticCurve(b, c, d, t);
        return Lerp(p0, p1, t);
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

        if (!superCruise.superCruiseActive) 
        {
            //run if holding brake pedal
            brakePressing = true;
        }
        
        
        
    }

    public void OnBrakeUp()
    {
        if (!superCruise.superCruiseActive) 
        {
            //run if release from brake pedal
            brakePressing = false;
        }
        
    }
}

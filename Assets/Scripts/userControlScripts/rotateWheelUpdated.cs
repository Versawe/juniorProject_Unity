using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateWheelUpdated : MonoBehaviour
{
    public bool heldDown = false;

    Vector2 centerPoint = new Vector2(0, 0);
    Vector2 touchPosition;

    public Transform wheel;
    public static float turnLimit = 0;
    public Transform driversWheel;


    RectTransform rectTrans;

    private bool back2Start = false;

    public static bool laneRightTurn = false;

    public static bool laneLeftTurn = false;

    private float laneCTimer = 0;

    public GameObject carBody;

    private bool isSuperCruiseLeft = false;

    private bool isSuperCruiseRight = false;

    private float easeTimer = 0;

    private float rotateNum;

    private float rotationValue;

    //following code is for quadrents of rotation and the actual position having to do with rotating the drivers wheel

    private int quadrent = 1;
    private int quadrentLast = 1;
    private bool quad1DidOnce = false;
    private bool quad2DidOnce = false;
    private bool quad3DidOnce = false;
    private bool quad4DidOnce = false;
    private bool hasRecordedInitialFingerPosition = false;

    private float angleOfTouch;
    private float initialFingerPosition;
    private float angleOfWheel;
    private float rotationActual;
    private float lastAngleOfWheel;
    private float angleOfRotationThisFrame;


    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        turnLimit = 0;

        //this finds the center vector2 position of the steering wheel for touch input
        centerPoint = Camera.main.ScreenToViewportPoint(wheel.position);

        laneLeftTurn = false;
        laneRightTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if you hold down on wheel the touch input is read only on the left side of the screen
        if (heldDown && laneCTimer <= 0)
        {
            foreach (Touch touch in Input.touches)
            {

                if (touch.position.x < Screen.width / 2 && !superCruise.superCruiseActive)
                {
                    touchPosition = Camera.main.ScreenToViewportPoint(touch.position);

                    //steers the wheel based on finger location compared to center point of wheel

                    /*
                    
                    if (touchPosition.x > centerPoint.x && turnLimit <= 1.5)
                    {
                        transform.Rotate(0, 0, -178 * Time.deltaTime);
                        turnLimit += 1 * Time.deltaTime;
                    }
                    if (touchPosition.x < centerPoint.x && turnLimit >= -1.5)
                    {
                        transform.Rotate(0, 0, 178 * Time.deltaTime);
                        turnLimit += -1 * Time.deltaTime;
                    }
                    */
                    

                    //The following code is a mess, but it handles the wheel's rotation.
                    angleOfTouch = (calcAngleFromCenter(centerPoint.x, centerPoint.y, touchPosition.x, touchPosition.y));

                    if(hasRecordedInitialFingerPosition == false)
                    {
                        initialFingerPosition = angleOfTouch;
                        hasRecordedInitialFingerPosition = true;
                    }

                    angleOfWheel = angleOfTouch; /*- initialFingerPosition;*/

                    if (angleOfWheel >= 0 && angleOfWheel < 90)
                    {
                        if(quad1DidOnce == false)
                        {
                            quadrentLast = quadrent;
                            quad1DidOnce = true;
                            quad2DidOnce = false;
                            quad3DidOnce = false;
                            quad4DidOnce = false;
                        }
                        quadrent = 1;
                    }

                    if (angleOfWheel >= 90 && angleOfWheel <= 180)
                    {
                        if (quad2DidOnce == false)
                        {
                            quadrentLast = quadrent;
                            quad1DidOnce = false;
                            quad2DidOnce = true;
                            quad3DidOnce = false;
                            quad4DidOnce = false;
                        }
                        quadrent = 2;
                    }

                    if (angleOfWheel <= -90 && angleOfWheel >= -180)
                    {
                        if (quad3DidOnce == false)
                        {
                            quadrentLast = quadrent;
                            quad1DidOnce = false;
                            quad2DidOnce = false;
                            quad3DidOnce = true;
                            quad4DidOnce = false;
                        }
                        quadrent = 3;
                    }

                    if (angleOfWheel < 0 && angleOfWheel > -90)
                    {
                        if (quad4DidOnce == false)
                        {
                            quadrentLast = quadrent;
                            quad1DidOnce = false;
                            quad2DidOnce = false;
                            quad3DidOnce = false;
                            quad4DidOnce = true;
                        }
                        quadrent = 4;
                    }

                    if (quadrent == 1)
                    {
                        if(quadrentLast == 2)
                        {
                            if(rotationActual > 0)
                            {
                                rotationActual = angleOfWheel;
                            }
                            if (rotationActual < 0)
                            {
                                rotationActual = -270;
                            }
                        }
                        if(quadrentLast == 4)
                        {
                            rotationActual = angleOfWheel;
                        }
                    }

                    if (quadrent == 2)
                    {
                        if(quadrentLast == 3)
                        {
                            if(rotationActual > 0)
                            {
                                rotationActual = angleOfWheel;
                            }
                            if(rotationActual < 0)
                            {
                                rotationActual = angleOfWheel - 360;
                            }
                        }
                        if(quadrentLast == 1)
                        {
                            if(rotationActual > 0)
                            {
                                rotationActual = angleOfWheel;
                            }
                            if (rotationActual < 0)
                            {
                                rotationActual = angleOfWheel -360;
                            }
                        }
                    }

                    if (quadrent == 3)
                    {
                        if(quadrentLast == 2)
                        {
                            if(rotationActual > 0)
                            {
                                rotationActual = angleOfWheel + 360;
                            }
                            if (rotationActual < 0)
                            {
                                rotationActual = angleOfWheel;
                            }
                        }
                        if(quadrentLast == 4)
                        {
                            if(rotationActual > 0)
                            {
                                rotationActual = angleOfWheel + 360;
                            }
                            if(rotationActual < 0)
                            {
                                rotationActual = angleOfWheel;
                            }
                        }
                    }

                    if (quadrent == 4)
                    {
                        if(quadrentLast == 1)
                        {
                            rotationActual = angleOfWheel;
                        }
                        if (quadrentLast == 3)
                        {
                            if(rotationActual > 0)
                            {
                                rotationActual = 270;
                            }
                            if(rotationActual < 0)
                            {
                                rotationActual = angleOfWheel;
                            }
                        }
                    }

                    turnLimit = -rotationActual / 150;


                    transform.rotation = Quaternion.Euler(0,0,rotationActual);
                }

            }

        }

        if(Input.GetKeyDown("d"))
        {
            transform.Rotate(0, 0, -178*4 * Time.deltaTime);
            //driversWheel.transform.Rotate(0, 0, 100 * Time.deltaTime);
            turnLimit += 4 * Time.deltaTime;
        }

        if (Input.GetKeyDown("a"))
        {
            transform.Rotate(0, 0, 178*4 * Time.deltaTime);
            //driversWheel.transform.Rotate(0, 0, -100 * Time.deltaTime);
            turnLimit += -4 * Time.deltaTime;
        }

        //wheel turning back to center position when user doesn't hold down on it
        if (laneCTimer <= 0)
        {
            if (back2Start && turnLimit > 0 + 0.15f)
            {
                transform.Rotate(0, 0, 178 * Time.deltaTime);
                turnLimit += -1 * Time.deltaTime;
            }
            if (back2Start && turnLimit < 0 + -0.15f)
            {
                transform.Rotate(0, 0, -178 * Time.deltaTime);
                turnLimit += 1 * Time.deltaTime;
            }
            if (back2Start && turnLimit < 0 + 0.15f && turnLimit > 0 + -0.15f)
            {
                rectTrans.localRotation = new Quaternion(0, 0, 0, 0);
                turnLimit = 0;
            }
        }
        

        // this is for the lane change feature and triggers depending on which side of the car you are on
        if (laneLeftTurn || laneRightTurn)
        {
            laneCTimer += 1 * Time.deltaTime;
        }
        if (laneCTimer >= 0.5f) //was 0.5f (might need to be longer)
        {
            if (laneLeftTurn)
            {
                isSuperCruiseLeft = true;
                //carBody.transform.rotation = Quaternion.Euler(0, -1f,0);
            }
            if (laneRightTurn)
            {
                isSuperCruiseRight = true;
                //carBody.transform.rotation = Quaternion.Euler(0, 1f, 0);
            }

            laneLeftTurn = false;
            laneRightTurn = false;
            rectTrans.localRotation = new Quaternion(0, 0, 0, 0);
            turnLimit = 0;
            laneCTimer = 0;
        }

        if (isSuperCruiseLeft || isSuperCruiseRight)
        {
            easeTimer += 0.25f * Time.deltaTime;
        }
        if (easeTimer >= 1)
        {
            easeTimer = 0;
            isSuperCruiseLeft = false;
            isSuperCruiseRight = false;
        }
        if (isSuperCruiseLeft)
        {
            rotateNum = carBody.transform.eulerAngles.y;
            rotateNum += -0.2f * Time.deltaTime;
            carBody.transform.rotation = Quaternion.Euler(0, rotateNum, 0);
        }

        if (isSuperCruiseRight)
        {
            rotateNum = carBody.transform.eulerAngles.y;
            rotateNum += 0.2f * Time.deltaTime;
            carBody.transform.rotation = Quaternion.Euler(0, rotateNum, 0);
        }

        //making car turn with lane change
        if (laneLeftTurn)
        {
            if (superCruise.superCruiseActive)
            {
                transform.Rotate(0, 0, 115 * Time.deltaTime);
                turnLimit += -.1f * Time.deltaTime;
            }
            if (!superCruise.superCruiseActive)
            {
                transform.Rotate(0, 0, 278 * Time.deltaTime);
                turnLimit += -4f * Time.deltaTime;
            }
            
        }
        if (laneRightTurn)
        {
            if (superCruise.superCruiseActive)
            {
                transform.Rotate(0, 0, -115 * Time.deltaTime);
                turnLimit += .1f * Time.deltaTime;
            }
            if (!superCruise.superCruiseActive)
            {
                transform.Rotate(0, 0, -278 * Time.deltaTime);
                turnLimit += 4f * Time.deltaTime;
            }
            
        }

        rotationValue = transform.localEulerAngles.z;

        //driversWheel.rotation = Quaternion.Euler(-24f, 180f, -rotationValue);
        driversWheel.rotation = Quaternion.Euler(-24f + carBody.transform.localEulerAngles.x, 180f + carBody.transform.localEulerAngles.y, -rotationValue);

        //print(transform.rotation.z);


    }


    public void OnTouchDown()
    {
        //run if you are hold down on wheel
        if (Input.touchCount > 0)
        {
            heldDown = true;
        }

        back2Start = false;
    }

    public void OnTouchExit()
    {
        //run if you release from wheel
        heldDown = false;
        touchPosition = new Vector2(0, 0);
        back2Start = true;
        hasRecordedInitialFingerPosition = false;
    }

    public float calcAngleFromCenter(float centerX, float centerY, float fingerX, float fingerY)
    {
        float distanceX = fingerX - centerX;
        float distanceY = fingerY - centerY;
        float radians = Mathf.Atan2(distanceY,distanceX);
        float degrees = radians * 180 / Mathf.PI;
        return degrees;
    }

}


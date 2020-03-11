using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateWheel : MonoBehaviour
{
    public bool heldDown = false;

    Vector2 centerPoint = new Vector2(0, 0);
    Vector2 touchPosition;

    public Transform wheel;
    public static float turnLimit = 0;


    RectTransform rectTrans;

    private bool back2Start = false;

    public static bool laneRightTurn = false;

    public static bool laneLeftTurn = false;

    private float laneCTimer = 0;

    public GameObject carBody;


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
                }

            }

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
        if (laneCTimer >= 0.2f) //was 0.5f
        {
            laneLeftTurn = false;
            laneRightTurn = false;
            rectTrans.localRotation = new Quaternion(0, 0, 0, 0);
            turnLimit = 0;
            carBody.transform.Rotate(0,0,0);
            laneCTimer = 0;
        }

        //making car turn with lane change
        if (laneLeftTurn)
        {
            if (superCruise.superCruiseActive)
            {
                transform.Rotate(0, 0, 150 * Time.deltaTime);
                turnLimit += -0.25f * Time.deltaTime;
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
                transform.Rotate(0, 0, -150 * Time.deltaTime);
                turnLimit += 0.25f * Time.deltaTime;
            }
            if (!superCruise.superCruiseActive)
            {
                transform.Rotate(0, 0, -278 * Time.deltaTime);
                turnLimit += 4f * Time.deltaTime;
            }
            
        }

        //print(turnLimit);

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
    }

}


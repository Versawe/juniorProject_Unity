using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.iOS;
//using UnityEngine.EventSystems;

public class rotateWheel : MonoBehaviour
{
    public bool heldDown = false;

    Vector2 initialTouch = new Vector2(0.15f,0.2f);
    Vector2 touchPosition;

    //private bool touchedDown = false;
    public Transform wheel;
    public static float turnLimit = 0;

    private bool firstTap = false;
    private bool secondTap = false;
    private float quickTapTimer = 0;

    public static bool touchedFirstWheel = false;

    public RectTransform rectTrans;

    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        turnLimit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Prints number of fingers touching the screen
        /*int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }*/

        //print("User has " + fingerCount + " finger(s) touching the screen");
        //print(Input.touches);


        if (heldDown)
        {
            Touch touch = Input.GetTouch(0);
            if (!carMovement.touchedFirstGas)
            {
                /*if (!touchedDown)
                  {
                      initialTouch = Camera.main.ScreenToViewportPoint(touch.position);
                  }*/
                //touchedDown = true;

                touchPosition = Camera.main.ScreenToViewportPoint(touch.position);

            }
            if (carMovement.touchedFirstGas)
            {
                touch = Input.GetTouch(1);

                /*if (!touchedDown)
                {
                    initialTouch = Camera.main.ScreenToViewportPoint(touch.position);
                }*/
                //touchedDown = true;
                touchPosition = Camera.main.ScreenToViewportPoint(touch.position);
            }
            
            
            /*if (Input.touchCount == 0)
            {
                touchedDown = false;
                initialTouch = new Vector2(0, 0);
                touchPosition = new Vector2(0, 0);
            }*/


            if (touchPosition.x > initialTouch.x && turnLimit >= -2.5)
            {
                transform.Rotate(0, 0, -150 * Time.deltaTime);
                turnLimit += -1 * Time.deltaTime;
            }
            if (touchPosition.x < initialTouch.x && turnLimit <= 2.5)
            {
                transform.Rotate(0, 0, 150 * Time.deltaTime);
                turnLimit += 1 * Time.deltaTime;
            }
        }

        if (quickTapTimer > 0)
        {
            quickTapTimer += 1 * Time.deltaTime;
        }
        if (quickTapTimer == 0)
        {
            firstTap = false;
        }
        if (quickTapTimer >= 0.3f)
        {
            firstTap = false;
            secondTap = false;
            quickTapTimer = 0;

        }

        if (secondTap)
        {
            //stuff happens here
            rectTrans.localRotation = new Quaternion(0,0,0,0);
            turnLimit = 0;
            //print(secondTap);
        }

        print(touchPosition.x);
    }


    public void OnTouchDown()
    {
        if (Input.touchCount > 0)
        {
            quickTapTimer += 0.1f * Time.deltaTime;

            heldDown = true;
            if (quickTapTimer > 0 && quickTapTimer < 0.3f && firstTap)
            {
                secondTap = true;
            }
            if (quickTapTimer > 0 && quickTapTimer < 0.2f)
            {
                firstTap = true;
            }
        }  
    }

    public void OnTouchExit()
    {
        heldDown = false;
        secondTap = false;
        //touchedDown = false;
        //initialTouch = new Vector2(0, 0);
        touchPosition = new Vector2(0, 0);
    }

   
}

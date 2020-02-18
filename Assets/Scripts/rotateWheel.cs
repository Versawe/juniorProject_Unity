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

    private bool turningRight = false;

    private bool turningLeft = false;

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


        if (heldDown)
        {
            Touch touch = Input.GetTouch(0);
            if(!carMovement.touchedFirstGas)
            {
                touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToViewportPoint(touch.position);

            }
            if(carMovement.touchedFirstGas)
            {
                touch = Input.GetTouch(1);
                touchPosition = Camera.main.ScreenToViewportPoint(touch.position);
            }
            

            if (touchPosition.x > initialTouch.x && turnLimit >= -2.5)
            {
                transform.Rotate(0, 0, -150 * Time.deltaTime);
                turnLimit += -1 * Time.deltaTime;
                turningRight = true;
                turningLeft = false;
            }
            if (touchPosition.x < initialTouch.x && turnLimit <= 2.5)
            {
                transform.Rotate(0, 0, 150 * Time.deltaTime);
                turnLimit += 1 * Time.deltaTime;
                turningLeft = true;
                turningRight = false;
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
        }

        print("We are Turning Left " + turningLeft);
        print("We are Turning Right " + turningRight);
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
        touchPosition = new Vector2(0, 0);
    }

    public void OnTouchRelease()
    {
        turningRight = false;
        turningLeft = false;
    }

   
}

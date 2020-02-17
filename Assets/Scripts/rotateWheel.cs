using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.iOS;
//using UnityEngine.EventSystems;

public class rotateWheel : MonoBehaviour
{
    public bool heldDown = false;

    Vector2 initialTouch;
    Vector2 touchPosition;

    private bool touchedDown = false;
    public Transform wheel;
    public static float turnLimit = 0;

    private bool firstTap = false;
    private bool secondTap = false;
    private float quickTapTimer = 0;

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
            if (Input.touchCount >= 1)
            {

                Touch touch = Input.GetTouch(0);

                if (!touchedDown)
                {
                    initialTouch = Camera.main.ScreenToViewportPoint(touch.position);
                }
                touchedDown = true;

                touchPosition = Camera.main.ScreenToViewportPoint(touch.position);


            }
            if (Input.touchCount < 1)
            {
                touchedDown = false;
                initialTouch = new Vector2(0, 0);
                touchPosition = new Vector2(0, 0);
            }


            if (touchPosition.x > initialTouch.x && turnLimit >= -2.75)
            {
                transform.Rotate(0, 0, -150 * Time.deltaTime);
                turnLimit += -1 * Time.deltaTime;
            }
            if (touchPosition.x < initialTouch.x && turnLimit <= 2.75)
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

        if (Input.touchCount <= 0)
        {
            heldDown = false;
            secondTap = false;
        }

        if (secondTap)
        {
            //stuff happens here
            rectTrans.localRotation = new Quaternion(0,0,0,0);
            turnLimit = 0;
            //print(secondTap);
        }

        print(initialTouch);
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

   
}

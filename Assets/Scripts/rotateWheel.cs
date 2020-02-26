using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateWheel : MonoBehaviour
{
    public bool heldDown = false;

    Vector2 centerPoint = new Vector2(0,0);
    Vector2 touchPosition;

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
        centerPoint = Camera.main.ScreenToViewportPoint(wheel.position);
    }

    // Update is called once per frame
    void Update()
    {

        if (heldDown)
        {
            foreach (Touch touch in Input.touches)
            {

                if (touch.position.x < Screen.width/2)
                {
                    touchPosition = Camera.main.ScreenToViewportPoint(touch.position);

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

        //print("tp " + touchPosition);
        //print("cp " + centerPoint);
        
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

   
}

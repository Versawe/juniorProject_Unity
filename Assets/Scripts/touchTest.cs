using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class touchTest : MonoBehaviour
{
    private bool touchedDown = false;

    private bool fingerMoving = false;

    private float touchTimer = 0;

    Vector2 checkForChange;

    Vector2 initialTouch;

    Vector2 touchPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 1)
        {

            Touch touch = Input.GetTouch(0);
            //touch.position
            //touch.phase

            if (!touchedDown)
            {
                initialTouch = Camera.main.ScreenToViewportPoint(touch.position);
            }
            touchedDown = true;

            touchPosition = Camera.main.ScreenToViewportPoint(touch.position);

            touchTimer += 1 * Time.deltaTime;


            if (touchTimer < 0.5f)
            {
                checkForChange = Camera.main.ScreenToViewportPoint(touch.position);
                fingerMoving = true;
            }
            if (touchTimer > 0.5f)
            {
                if (checkForChange.x == touchPosition.x)
                {
                    fingerMoving = false;
                    initialTouch = Camera.main.ScreenToViewportPoint(touch.position);
                    touchPosition = Camera.main.ScreenToViewportPoint(touch.position);
                }
                if (checkForChange.x != touchPosition.x)
                {
                    touchTimer = 0;
                }
                
            }
            
        }
        if (Input.touchCount < 1)
        {
            touchedDown = false;
            initialTouch = new Vector2(0,0);
            touchPosition = new Vector2(0, 0);
            checkForChange = new Vector2(0,0);
            fingerMoving = false;
            touchTimer = 0;
        }


        if (fingerMoving && touchPosition.x > initialTouch.x)
        {
            transform.Rotate(0,-250 * Time.deltaTime,0);
        }
        if (fingerMoving && touchPosition.x < initialTouch.x)
        {
            transform.Rotate(0, 250 * Time.deltaTime, 0);
        }

        //print(initialTouch);
    }

}

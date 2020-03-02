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


    public RectTransform rectTrans;

    private bool back2Start = false;


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

                if (touch.position.x < Screen.width / 2)
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
        //print(turnLimit);
    }


    public void OnTouchDown()
    {
        if (Input.touchCount > 0)
        {
            heldDown = true;
        }

        back2Start = false;
    }

    public void OnTouchExit()
    {
        heldDown = false;
        touchPosition = new Vector2(0, 0);
        back2Start = true;
    }


}


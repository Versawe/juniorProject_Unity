using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    private float speed = 0;
    private float maxSpeed = 390;
    public static bool movingForward = false;
    public static bool brakePressing = false;

    Vector2 touchPoint;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        movingForward = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Physics.IgnoreLayerCollision(8,9);

        if (speed <= 0)
        {
            speed = 0;
        }
        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
        if (movingForward)
        {
            speed += 128 * Time.deltaTime;
        }
        if (!movingForward && speed > 0)
        {
            speed += -58 * Time.deltaTime;
        }

        if (brakePressing)
        {
            speed += -108 * Time.deltaTime;
        }

        rb.velocity = transform.forward * speed * Time.deltaTime;

        if (speed > 0)
        {
            transform.Rotate(0, rotateWheel.turnLimit * 23 * Time.deltaTime, 0);
        }

        foreach (Touch touch in Input.touches)
        {

            if (touch.position.x > Screen.width/2)
            {
                
                touchPoint = Camera.main.ScreenToViewportPoint(touch.position);

            }

        }

    }

    public void OnGasDown()
    {
        movingForward = true;
    }

    public void OnGasUp()
    {
        movingForward = false;
    }

    public void OnBrakeDown()
    {
        brakePressing = true;
    }

    public void OnBrakeUp()
    {
        brakePressing = false;
    }
}

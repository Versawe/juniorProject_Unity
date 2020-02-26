using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gearShifterScript : MonoBehaviour
{
    public Slider gear;

    public static bool inPark = true;
    public static bool inReverse = false;
    public static bool inDrive = false;

    // Start is called before the first frame update
    void Start()
    {
        inPark = true;
}

    // Update is called once per frame
    void Update()
    {
        if (gear.GetComponent<Slider>().value == 0)
        {
            inPark = true;
            inDrive = false;
            inReverse = false;
        }
        if (gear.GetComponent<Slider>().value == 1)
        {
            inReverse = true;
            inPark = false;
            inDrive = false;
        }
        if (gear.GetComponent<Slider>().value == 2)
        {
            inDrive = true;
            inPark = false;
            inReverse = false;
        }

        if (carMovement.speed > 0)
        {
            inDrive = true;
            gear.GetComponent<Slider>().value = 2;
        }

        if (carMovement.reverseSpeed > 0)
        {
            inReverse = true;
            gear.GetComponent<Slider>().value = 1;
        }

    }

    public void sliderCheckStatus()
    {
        if (gear.GetComponent<Slider>().value != 0 && gear.GetComponent<Slider>().value < 0.5f)
        {
            gear.GetComponent<Slider>().value = 0;
        }

        if (gear.GetComponent<Slider>().value != 1 && gear.GetComponent<Slider>().value >= 0.5f && gear.GetComponent<Slider>().value <= 1.5f)
        {
            gear.GetComponent<Slider>().value = 1;
        }

        if (gear.GetComponent<Slider>().value != 2 && gear.GetComponent<Slider>().value > 1.5f)
        {
            gear.GetComponent<Slider>().value = 2;
        }
    }
}

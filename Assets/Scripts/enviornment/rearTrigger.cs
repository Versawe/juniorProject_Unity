using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rearTrigger : MonoBehaviour
{
    private bool isAutoBraking = false;

    private bool isAlerting = false;
    private bool leftAlert = false;
    private bool rightAlert = false;
    public GameObject playerCar;
    GameObject nearPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutoBraking) 
        {
            if (gearShifterScript.inReverse)
            {
                carMovement.brakePressing = true;
            }
            if (gearShifterScript.inDrive || gearShifterScript.inPark)
            {
                carMovement.brakePressing = false;
                isAutoBraking = false;
            }
        }

        if (isAlerting) 
        {
            if (gearShifterScript.inDrive || gearShifterScript.inPark)
            {
                isAlerting = false;
            }
        }

        if (!isAlerting) 
        {
            rightAlert = false;
            leftAlert = false;
            nearPlayer = null;
        }
        if (rightAlert) 
        {
            print("Right ALERTTTTT");
        }
        if (leftAlert) 
        {
            print("Left Alert");
        }

        //print(safteyFeature.autoRearBrakeTrigger);

    }

    private void OnTriggerStay(Collider other)
    {
        if (safteyFeature.autoRearBrakeTrigger)
        {
            if (other.gameObject.tag == "AI")
            {
                isAutoBraking = true;
            }
        }

        if (safteyFeature.crossTrafficTrigger)
        {
            if (other.gameObject.tag == "AI")
            {
                isAlerting = true;
                nearPlayer = other.gameObject;
            }

            if(playerCar.transform.position.x >= nearPlayer.transform.position.x) 
            {
                if (playerCar.transform.position.z >= nearPlayer.transform.position.z)
                {
                    leftAlert = true;
                    rightAlert = false;
                }
                if (playerCar.transform.position.z < nearPlayer.transform.position.z)
                {
                    rightAlert = true;
                    leftAlert = false;
                }
            }
            if (playerCar.transform.position.x < nearPlayer.transform.position.x)
            {
                if (playerCar.transform.position.z >= nearPlayer.transform.position.z)
                {
                    leftAlert = false;
                    rightAlert = true;
                }
                if (playerCar.transform.position.z < nearPlayer.transform.position.z)
                {
                    rightAlert = false;
                    leftAlert = true;
                }
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (safteyFeature.autoRearBrakeTrigger)
        {
            // stop doing thing here
        }

        if (safteyFeature.crossTrafficTrigger)
        {

            isAlerting = false;
        }
    }
}

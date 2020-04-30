using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rearTrigger : MonoBehaviour
{
    private bool isAutoBraking = false;

    private bool isAlerting = false;
    private bool leftAlert = false;
    private bool rightAlert = false;
    private int blinkDelayRight = 0;
    private int blinkCountRight = 0;
    private int blinkDelayLeft = 0;
    private int blinkCountLeft = 0;
    private int switchOnAndOffRight = 0;
    private int switchOnAndOffLeft = 0;
    //private bool uiCrossTrafficRightActive = false;
    //private bool uiCrossTrafficleftActive = false;
    public GameObject uiCrossTrafficRight;
    public GameObject uiCrossTrafficLeft;
    public GameObject playerCar;
    GameObject nearPlayer;
    // Start is called before the first frame update
    void Start()
    {
        uiCrossTrafficRight.SetActive(false);
        uiCrossTrafficLeft.SetActive(false);
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
            //print("Right ALERTTTTT");
            if (!textTriggers.activateSecondText && safteyFeature.crossTrafficTrigger) 
            {
                textTriggers.activateSecondText = true;
            }

            if(blinkCountRight < 9 && blinkDelayRight <= 0)
            {
                switch (switchOnAndOffRight)
                {
                    case 0:
                        switchOnAndOffRight = 1;
                        uiCrossTrafficRight.SetActive(true);
                        break;
                    case 1:
                        switchOnAndOffRight = 0;
                        uiCrossTrafficRight.SetActive(false);
                        break;
                }
                blinkDelayRight = 20;
                blinkCountRight += 1;
            }
            blinkDelayRight -= 1;
        }
        if (leftAlert) 
        {
            //print("Left Alert");
            if (!textTriggers.activateSecondText && safteyFeature.crossTrafficTrigger)
            {
                textTriggers.activateSecondText = true;
            }

            if (blinkCountLeft < 9 && blinkDelayLeft <= 0)
            {
                switch (switchOnAndOffLeft)
                {
                    case 0:
                        switchOnAndOffLeft = 1;
                        uiCrossTrafficLeft.SetActive(true);
                        break;
                    case 1:
                        switchOnAndOffLeft = 0;
                        uiCrossTrafficLeft.SetActive(false);
                        break;
                }
                blinkDelayLeft = 20;
                blinkCountLeft += 1;
            }
            blinkDelayLeft -= 1;
        }
        if(!rightAlert)
        {
            blinkDelayRight = 0;
            blinkCountRight = 0;
            uiCrossTrafficRight.SetActive(false);
            switchOnAndOffRight = 0;
        }
        if (!leftAlert)
        {
            blinkDelayLeft = 0;
            blinkCountLeft = 0;
            uiCrossTrafficLeft.SetActive(false);
            switchOnAndOffLeft = 0;
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
                if (!textTriggers.firstBraked && safteyFeature.autoRearBrakeTrigger) 
                {
                    textTriggers.firstBraked = true;
                }
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

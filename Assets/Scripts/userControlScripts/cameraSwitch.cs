using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public GameObject cameraDrive;
    public GameObject cameraReverse;
    public GameObject cameraActual;
    public GameObject screen;
    private Quaternion cameraActualRot;
    private Quaternion cameraReverseRot;
    private Quaternion cameraDriveRot;
    private Quaternion targetRot;
    private Vector3 targetLocation;
    public GameObject gyroDude;
    float speedRot = .01f;
    float progressRot;
    float speedLoc = .01f;
    float progressLoc;
    private bool reverseCamOn;

    BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        Vector3 cameraNormalLocation = cameraDrive.transform.position;
        Vector3 cameraReverseLocation = cameraReverse.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gyroOff.boolBro)
        {
            gyroDude.GetComponent<followGyro>().enabled = false;
        }
        else
        {
            gyroDude.GetComponent<followGyro>().enabled = true;
        }


        Vector3 cameraCurrentLocation = cameraActual.transform.position;
        cameraActualRot = cameraActual.transform.rotation;
        cameraDriveRot = cameraDrive.transform.rotation;
        cameraReverseRot = cameraReverse.transform.rotation;

        if (!gearShifterScript.inReverse && gearShifterScript.inDrive) 
        {
            reverseCamOn = false;
            bc.enabled = false;
        }
        if (!gearShifterScript.inReverse && gearShifterScript.inPark) 
        {
            reverseCamOn = false;
            bc.enabled = false;
        }

        if (gearShifterScript.inReverse && !gearShifterScript.inDrive) 
        {
            reverseCamOn = true;
            bc.enabled = true;
        }

        if (reverseCamOn)
        {
            targetLocation = cameraReverse.transform.position;
            targetRot = cameraReverseRot;
            screen.SetActive(true);
        }

        if (!reverseCamOn)
        {
            targetLocation = cameraDrive.transform.position;
            targetRot = cameraDriveRot;
            screen.SetActive(false);
        }

        progressRot += speedRot * Time.deltaTime;
        progressRot = Mathf.Clamp01(progressRot);
        progressLoc += speedLoc * Time.deltaTime;
        progressLoc = Mathf.Clamp01(progressLoc);

        cameraActual.transform.rotation = Quaternion.Slerp(cameraActualRot, targetRot, progressRot);
        cameraActual.transform.position = Vector3.Slerp(cameraCurrentLocation, targetLocation, progressLoc);
    }
}

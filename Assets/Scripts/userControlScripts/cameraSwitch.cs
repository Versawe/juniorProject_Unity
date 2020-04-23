using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public GameObject cameraDrive;
    public GameObject cameraReverse;
    public GameObject cameraActual;
    public GameObject screen;
    private Vector3 targetLocation;
    private float xRot;
    private float yRot;
    private float zRot;
    private float xRotTarget;
    private float yRotTarget;
    private float zRotTarget;
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
    void Update()
    {
        Vector3 cameraCurrentLocation = cameraActual.transform.position;
        xRot = cameraActual.transform.eulerAngles.x;
        yRot = cameraActual.transform.eulerAngles.y;
        zRot = cameraActual.transform.eulerAngles.z;


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
            /*
            cameraActual.transform.position = cameraTarget.transform.position;
            cameraActual.transform.rotation = cameraTarget.transform.rotation;
            */
            targetLocation = cameraReverse.transform.position;
            xRotTarget = cameraReverse.transform.eulerAngles.x;
            yRotTarget = cameraReverse.transform.eulerAngles.y;
            zRotTarget = cameraReverse.transform.eulerAngles.z;
            screen.SetActive(true);
        }

        if (!reverseCamOn)
        {
            /*
            cameraActual.transform.position = cameraPOV.transform.position;
            cameraActual.transform.rotation = cameraPOV.transform.rotation;
            */
            targetLocation = cameraDrive.transform.position;
            xRotTarget = cameraDrive.transform.eulerAngles.x;
            yRotTarget = cameraDrive.transform.eulerAngles.y;
            zRotTarget = cameraDrive.transform.eulerAngles.z;
            screen.SetActive(false);
        }

        cameraCurrentLocation.x = Transition(cameraCurrentLocation.x, targetLocation.x, 5f);
        cameraCurrentLocation.y = Transition(cameraCurrentLocation.y, targetLocation.y, 5f);
        cameraCurrentLocation.z = Transition(cameraCurrentLocation.z, targetLocation.z, 5f);
        /*
        xRot = Transition(xRot, xRotTarget, 5);
        yRot = Transition(yRot, yRotTarget, 5);
        zRot = Transition(zRot, zRotTarget, 5);
        */
        xRot = xRotTarget;
        yRot = yRotTarget;
        zRot = zRotTarget;

        //print(xRot);

        cameraActual.transform.position = cameraCurrentLocation;
        cameraActual.transform.rotation = Quaternion.Euler(xRot, yRot, zRot);
    }

    public float Transition(float startValue, float endValue, float speed)
    {
        float newValue = (((endValue - startValue) / 100) * speed) + startValue;
        return newValue;
    }
}

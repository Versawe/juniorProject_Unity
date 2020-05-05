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
    float speed = .01f;
    float progress;
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
        cameraActualRot = cameraActual.transform.rotation;
        cameraReverseRot = cameraReverse.transform.rotation;
        cameraDriveRot = cameraDrive.transform.rotation;
        /*
        xRot = cameraActual.transform.eulerAngles.x;
        yRot = cameraActual.transform.eulerAngles.y;
        zRot = cameraActual.transform.eulerAngles.z;
        */

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
            targetRot = cameraReverseRot;
            /*
            xRotTarget = cameraReverse.transform.eulerAngles.x;
            yRotTarget = cameraReverse.transform.eulerAngles.y;
            zRotTarget = cameraReverse.transform.eulerAngles.z;
            */
            screen.SetActive(true);
        }

        if (!reverseCamOn)
        {
            /*
            cameraActual.transform.position = cameraPOV.transform.position;
            cameraActual.transform.rotation = cameraPOV.transform.rotation;
            */
            targetLocation = cameraDrive.transform.position;
            targetRot = cameraDriveRot;
            /*
            xRotTarget = cameraReverse.transform.eulerAngles.x;
            yRotTarget = cameraReverse.transform.eulerAngles.y;
            zRotTarget = cameraReverse.transform.eulerAngles.z;
            */
            screen.SetActive(false);
        }

        /*
        xRot = Transition(xRot, xRotTarget, 5);
        yRot = Transition(yRot, yRotTarget, 5);
        zRot = Transition(zRot, zRotTarget, 5);
        */
        /*
        xRot = xRotTarget;
        yRot = yRotTarget;
        zRot = zRotTarget;
        */

        //print(xRot);

        cameraCurrentLocation.x = Transition(cameraCurrentLocation.x, targetLocation.x, 5f);
        cameraCurrentLocation.y = Transition(cameraCurrentLocation.y, targetLocation.y, 5f);
        cameraCurrentLocation.z = Transition(cameraCurrentLocation.z, targetLocation.z, 5f);
        
        progress += speed * Time.deltaTime;
        progress = Mathf.Clamp01(progress);

        cameraActual.transform.rotation = Quaternion.Lerp(cameraActualRot, targetRot, progress);
        //cameraActual.transform.rotation = cameraActualRot;

        cameraActual.transform.position = cameraCurrentLocation;
    }

    public float Transition(float startValue, float endValue, float speed)
    {
        float newValue = (((endValue - startValue) / 100) * speed) + startValue;
        return newValue;
    }
}

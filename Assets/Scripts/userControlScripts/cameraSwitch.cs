using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public GameObject cameraPOV;
    public GameObject cameraRear;
    public GameObject cameraActual;
    private bool reverseCamOn;

    BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
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
            cameraActual.transform.position = cameraRear.transform.position;
            cameraActual.transform.rotation = cameraRear.transform.rotation;
        }

        if (!reverseCamOn)
        {
            cameraActual.transform.position = cameraPOV.transform.position;
            cameraActual.transform.rotation = cameraPOV.transform.rotation;
        }

    }
}

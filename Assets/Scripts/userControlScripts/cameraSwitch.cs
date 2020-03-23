using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public GameObject cameraPOV;
    public GameObject cameraRear;
    public GameObject cameraActual;
    private bool reverseCamOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gearShifterScript.inReverse && gearShifterScript.inDrive) reverseCamOn = false;

        if (gearShifterScript.inReverse && !gearShifterScript.inDrive) reverseCamOn = true;

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

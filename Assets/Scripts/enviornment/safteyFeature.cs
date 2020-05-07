using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class safteyFeature : MonoBehaviour
{
    Scene sc;

    private string sceneName;
    public static bool isSuperCruise = false;
    public static bool autoRearBrakeTrigger = false;
    public static bool crossTrafficTrigger = false;


    void Awake()
    {
        sc = SceneManager.GetActiveScene();
        sceneName = sc.name;

        if (sceneName == "superCruiseScene")
        {
            isSuperCruise = true;
            if (gyroOff.boolBro)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else isSuperCruise = false;

        if (sceneName == "crossTrafficAlert")
        {
            crossTrafficTrigger = true;
            if (gyroOff.boolBro)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        else crossTrafficTrigger = false;

        if (sceneName == "autoRearBrake")
        {
            autoRearBrakeTrigger = true;
            if (gyroOff.boolBro)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        else autoRearBrakeTrigger = false;
    }

    void Update()
    {
        
    
    }

}

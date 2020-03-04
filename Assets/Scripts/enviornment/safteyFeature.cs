using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class safteyFeature : MonoBehaviour
{
    Scene sc;

    private string sceneName;
    public static bool isSuperCruise = false;


    void Awake()
    {
        sc = SceneManager.GetActiveScene();
        sceneName = sc.name;

        if (sceneName == "superCruiseScene")
        {
            isSuperCruise = true;
        }
        else isSuperCruise = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superCruise : MonoBehaviour
{

    private int sc = 0;
    public static bool superCruiseActive = false;


    // Start is called before the first frame update
    void Start()
    {
        sc = 0;
        superCruiseActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickSC()
    {
        if (carMovement.speed >= 700)
        {
            switch (sc)
            {
                case 0:
                    sc = 1;
                    superCruiseActive = true;
                    break;
                case 1:
                    sc = 0;
                    superCruiseActive = false;
                    break;

            }
        }
        
    }
}

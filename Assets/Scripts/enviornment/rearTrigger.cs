using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rearTrigger : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (safteyFeature.autoRearBrakeTrigger)
        {
            if (other.gameObject.tag == "AI")
            {
                print("gay");
            }
        }

        if (safteyFeature.crossTrafficTrigger)
        {
            if (other.gameObject.tag == "AI")
            {
                print("gayer");
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
            //stop doing other thing here
        }
    }
}

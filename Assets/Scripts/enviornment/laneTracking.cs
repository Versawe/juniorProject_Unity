using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laneTracking : MonoBehaviour
{
    public Transform thisLane;

    GameObject playerCar; 
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("carBox"))
        {
            playerCar = GameObject.Find("carBox");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (superCruise.superCruiseActive)
        {
            if (playerCar.transform.position.x < +thisLane.position.x + 1.3f && playerCar.transform.position.x > thisLane.position.x -1.5f) //was both 1.5
            {
                if (playerCar.transform.position.x > thisLane.position.x)
                {
                    rotateWheel.laneRightTurn = true;
                }
                if (playerCar.transform.position.x < thisLane.position.x)
                {
                    rotateWheel.laneLeftTurn = true;
                }
            }
        }
    }
}

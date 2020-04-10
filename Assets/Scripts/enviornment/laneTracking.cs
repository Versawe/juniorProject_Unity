using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laneTracking : MonoBehaviour
{
    public Transform thisLane;

    GameObject playerCar;

    BoxCollider bc;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();

        if (GameObject.Find("carPrefabCTA"))
        {
            playerCar = GameObject.Find("carPrefabCTA");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!superCruise.superCruiseActive) bc.enabled = false;

        if (superCruise.superCruiseActive)
        {
            if (playerCar.transform.position.x < thisLane.position.x + 2f && playerCar.transform.position.x > thisLane.position.x -2f) //was both 1.5
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
            bc.enabled = true;
            //playerCar.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "carBox")
        {
            if(thisLane.gameObject.name == "shoulder1")
            {
                playerCar.transform.Rotate(0,-0.75f,0);
                //print("shoudler1");
            }
            if (thisLane.gameObject.name == "shoulder2")
            {
                playerCar.transform.Rotate(0, 0.75f, 0);
                //print("shoudler2");
            }
            if (thisLane.gameObject.name == "lane")
            {
                if (playerCar.transform.position.x > thisLane.position.x)
                {
                    playerCar.transform.Rotate(0, -0.75f, 0);
                    //print("right of middle lane");
                }
                if (playerCar.transform.position.x < thisLane.position.x)
                {
                    playerCar.transform.Rotate(0, 0.75f, 0);
                    //print("left of middle lane");

                }
            }
            if (thisLane.gameObject.name == "lane2")
            {
                if (playerCar.transform.position.x > thisLane.position.x)
                {
                    playerCar.transform.Rotate(0, -0.75f, 0);
                    //print("right of middle lane");
                }
                if (playerCar.transform.position.x < thisLane.position.x)
                {
                    playerCar.transform.Rotate(0, 0.75f, 0);
                    //print("left of middle lane");

                }
            }
            if (thisLane.gameObject.name == "lane3")
            {
                if (playerCar.transform.position.x > thisLane.position.x)
                {
                    playerCar.transform.Rotate(0, -0.75f, 0);
                    //print("right of middle lane");
                }
                if (playerCar.transform.position.x < thisLane.position.x)
                {
                    playerCar.transform.Rotate(0, 0.75f, 0);
                    //print("left of middle lane");

                }
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textTriggers : MonoBehaviour
{
    //Tutorial UI
    public GameObject tutorialMain;
    public Image gearArrow;
    public Image brakeGasArrow;
    public Image steeringArrow;
    public TextMeshProUGUI gearText;
    public TextMeshProUGUI brakeGasText;
    public TextMeshProUGUI steeringWheelText;

    //superCruise UI
    public GameObject superCruiseMain;
    public Image scArrow;
    public TextMeshProUGUI scText1;
    public TextMeshProUGUI scText2;
    public TextMeshProUGUI scText3;
    public TextMeshProUGUI scText4;

    //rearBrake UI
    public GameObject rearBrakeMain;
    public TextMeshProUGUI rbText1;
    public TextMeshProUGUI rbText2;
    public TextMeshProUGUI rbText3;

    //crossTraffic UI
    public GameObject crossTrafficMain;
    public TextMeshProUGUI ctText1;
    public TextMeshProUGUI ctbText2;

    //activate variables
    public static bool tutorialOnce = false;
    private float tutorialtTimer = 0;

    
    private float scTimer = 0;
    public static bool justStarted = false;
    public static bool firstActivated = false;
    public static bool firstWheelMovement = false;
    public static bool lastTextActivate = false;
    public static bool oneCycleSC = false;

    private float rbTimer = 0;
    public static bool onSceneLoad = false;
    public static bool firstBraked = false;
    public static bool rbLastTextActivate = false;

    private float ctTimer = 0;
    public static bool activateSecondText = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tutorial HERE
        if (!tutorialOnce && !pauseFunction.isPaused) 
        {
            tutorialtTimer += 1 * Time.deltaTime;
            if (tutorialtTimer > 3) 
            {
                Time.timeScale = 0.05f;
            }
            if (tutorialtTimer >= 3f && tutorialtTimer < 3.30f) 
            {
                gearText.gameObject.SetActive(true);
                gearArrow.gameObject.SetActive(true);
            }
            if (tutorialtTimer >= 3.30f && tutorialtTimer < 3.60f)
            {
                gearText.gameObject.SetActive(false);
                gearArrow.gameObject.SetActive(false);
                brakeGasArrow.gameObject.SetActive(true);
                brakeGasText.gameObject.SetActive(true);
            }
            if (tutorialtTimer >= 3.60f && tutorialtTimer < 3.9f) 
            {
                brakeGasArrow.gameObject.SetActive(false);
                brakeGasText.gameObject.SetActive(false);
                steeringWheelText.gameObject.SetActive(true);
                steeringArrow.gameObject.SetActive(true);
            }
            if (tutorialtTimer >= 3.9f)
            {
                steeringWheelText.gameObject.SetActive(false);
                steeringArrow.gameObject.SetActive(false);
                Time.timeScale = 1f;
                tutorialtTimer = 0;
                tutorialOnce = true;
            }

        }

        //if tutorial isnt happening
        if (tutorialOnce) 
        {
            // super cruise texts HERE
            if (safteyFeature.isSuperCruise)
            {
                if (!justStarted)
                {
                    scTimer += 1 * Time.deltaTime;
                    if (scTimer > 3f && scTimer < 3.30f)
                    {
                        Time.timeScale = 0.05f;
                        scText1.gameObject.SetActive(true);
                        scArrow.gameObject.SetActive(true);
                    }
                    if (scTimer >= 3.30f && scTimer < 3.60f)
                    {
                        Time.timeScale = 1f;
                        scText1.gameObject.SetActive(false);
                        scArrow.gameObject.SetActive(false);
                        scTimer = 0;
                        justStarted = true;
                    }
                }
                if (justStarted)
                {
                    if (firstActivated)
                    {
                        scTimer += 1 * Time.deltaTime;
                    }
                    if (firstActivated && scTimer > 3f && scTimer < 3.30f)
                    {
                        Time.timeScale = 0.05f;
                        scText2.gameObject.SetActive(true);
                    }
                    if (scTimer >= 3.30f && scTimer < 3.60f)
                    {
                        Time.timeScale = 1f;
                        scText2.gameObject.SetActive(false);
                        scTimer = 0;
                    }
                }

                if (firstActivated)
                {
                    if (firstWheelMovement)
                    {
                        Time.timeScale = 0.05f;
                        scText3.gameObject.SetActive(true);

                    }
                }
            }

            // auto rear brake text HERE

        }
        
        
    }
}

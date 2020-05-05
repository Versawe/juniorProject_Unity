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
    public Image tutorialTextBG;
    public Button tutorialNextButton;

    //superCruise UI
    public GameObject superCruiseMain;
    public Image scArrow;
    public TextMeshProUGUI scText1;
    public TextMeshProUGUI scText2;
    public TextMeshProUGUI scText3;
    public TextMeshProUGUI scText4;
    public Image scTextBG;
    public Button scNextButton;
    //public Button scNewButton;
    //public Image scNewBG;


    //rearBrake UI
    public GameObject rearBrakeMain;
    public TextMeshProUGUI rbText1;
    public TextMeshProUGUI rbText2;
    public TextMeshProUGUI rbText3;
    public Image rbTextBG;
    public Button rbNextButton;
    //public Button rbNewButton;
    //public Image rbNewBG;

    //crossTraffic UI
    public GameObject crossTrafficMain;
    public TextMeshProUGUI ctText1;
    public TextMeshProUGUI ctText2;
    public Image ctTextBG;
    public Button ctNextButton;

    //activate variables
    public static bool tutorialOnce = false; // skips tutorial if true
    private float tutorialtTimer = 0;
    private int tutorialNext = 0;
    
    private float scTimer = 0;
    private int scNext = 0;
    public static bool scTimerOff = false;
    public static bool justStarted = false;
    public static bool firstActivated = false;
    public static bool firstActivated2 = false;
    public static bool firstWheelMovement = false;
    public static bool lastTextActivate = false;
    public static bool oneCycleSC = false;

    private float rbTimer = 0;
    public static bool onSceneLoad = false;
    public static bool firstBraked = false;
    public static bool rbLastTextActivate = false;
    private int rbNext = 0;

    private float ctTimer = 0;
    public static bool activateFirstText = false;
    public static bool activateSecondText = false;
    public static bool endTexts = false;
    private int ctNext = 0;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //print(firstActivated2);
        //print(firstWheelMovement);
        //tutorial HERE
        if (!tutorialOnce && !pauseFunction.isPaused) 
        {
            tutorialtTimer += 1 * Time.deltaTime;
            
            if (tutorialtTimer > 3) 
            {
                //Time.timeScale = 0.05f;
            }
            if (tutorialtTimer >= 3f && tutorialtTimer < 3.01f) 
            {
                gearText.gameObject.SetActive(true);
                gearArrow.gameObject.SetActive(true);
                tutorialTextBG.gameObject.SetActive(true);
                tutorialNextButton.gameObject.SetActive(true);
                tutorialNext = 1;
            }

        }

        //if tutorial isnt happening
        if (tutorialOnce) 
        {
            // super cruise texts HERE
            if (safteyFeature.isSuperCruise && !pauseFunction.isPaused)
            {
                if (!justStarted && tutorialOnce)
                {
                    scTimer += 1 * Time.deltaTime;
                    if (scTimer > 3f && scTimer < 3.05f)
                    {
                        //Time.timeScale = 0.05f;
                        scText1.gameObject.SetActive(true);
                        scArrow.gameObject.SetActive(true);
                        scNextButton.gameObject.SetActive(true);
                        scTextBG.gameObject.SetActive(true);

                    }
                    if (scNext == 1 && !justStarted)
                    {
                        Time.timeScale = 1f;
                        scText1.gameObject.SetActive(false);
                        scArrow.gameObject.SetActive(false);
                        scNextButton.gameObject.SetActive(false);
                        scTextBG.gameObject.SetActive(false);
                        scTimer = 0;
                        justStarted = true;
                    }
                }
                if (justStarted && !firstActivated2)
                {
                    if (firstActivated)
                    {
                        scTimer += 1 * Time.deltaTime;
                    }
                    if (firstActivated && scTimer > 1f && scTimer < 1.05f)
                    {
                        //Time.timeScale = 0.05f;
                        scText2.gameObject.SetActive(true);
                        scNextButton.gameObject.SetActive(true);
                        scTextBG.gameObject.SetActive(true);
                    }
                    if (scNext == 2 && !firstActivated2)
                    {
                        Time.timeScale = 1f;
                        scText2.gameObject.SetActive(false);
                        scNextButton.gameObject.SetActive(false);
                        scTextBG.gameObject.SetActive(false);
                        scTimer = 0;
                        firstActivated2 = true;
                    }
                }

                if (firstActivated2 && firstWheelMovement)
                {
                    scTimer += 1 * Time.deltaTime;
                    if (scTimer > 1f && scTimer < 1.05f) 
                    {
                        //Time.timeScale = 0.05f;
                        scText3.gameObject.SetActive(true);
                        scNextButton.gameObject.SetActive(true);
                        scTextBG.gameObject.SetActive(true);
                    }
                    if (scNext == 3)
                    {
                        Time.timeScale = 1f;
                        scText3.gameObject.SetActive(false);
                        scNextButton.gameObject.SetActive(false);
                        scTextBG.gameObject.SetActive(false);
                    }
                    if (scNext == 3)
                    {
                        //Time.timeScale = 0.05f;
                        scText4.gameObject.SetActive(true);
                        scNextButton.gameObject.SetActive(true);
                        scTextBG.gameObject.SetActive(true);
                    }
                    if (scNext == 4)
                    {
                        Time.timeScale = 1f;
                        scText4.gameObject.SetActive(false);
                        scNextButton.gameObject.SetActive(false);
                        scTextBG.gameObject.SetActive(false);
                        scTimerOff = true;
                    }

                }
                if (scTimerOff) 
                {
                    scTimer = 0;
                }
            }

            // auto rear brake text HERE
            if (safteyFeature.autoRearBrakeTrigger && !pauseFunction.isPaused) 
            {
                if (!onSceneLoad) 
                {
                    rbTimer += 1 * Time.deltaTime;
                }
                if (!onSceneLoad && rbTimer >= 3f && rbTimer <= 3.01f) 
                {
                    //Time.timeScale = 0.05f;
                    rbText1.gameObject.SetActive(true);
                    rbNextButton.gameObject.SetActive(true);
                    rbTextBG.gameObject.SetActive(true);
                }
                if (onSceneLoad && firstBraked) 
                {
                    rbTimer += 1 * Time.deltaTime;
                }
                if (firstBraked && onSceneLoad && rbTimer >= 1f && rbTimer < 1.05f) 
                {
                    //Time.timeScale = 0.05f;
                    rbText2.gameObject.SetActive(true);
                    rbNextButton.gameObject.SetActive(true);
                    rbTextBG.gameObject.SetActive(true);
                    rbNext = 2;
                }
                if (firstBraked && onSceneLoad && rbNext == 3)
                {
                    //Time.timeScale = 0.05f;
                    rbText3.gameObject.SetActive(true);
                    rbNextButton.gameObject.SetActive(true);
                    rbTextBG.gameObject.SetActive(true);
                }
                if (rbLastTextActivate) 
                {
                    rbTimer = 0;
                }
            }

            //cross traffic text HERE
            if (safteyFeature.crossTrafficTrigger && !pauseFunction.isPaused) 
            {
                if(!activateFirstText && tutorialOnce) 
                {
                    ctTimer += 1 * Time.deltaTime;
                }
                if (!activateFirstText && ctTimer >= 3f && ctTimer < 3.05f) 
                {
                    //Time.timeScale = 0.05f;
                    ctText1.gameObject.SetActive(true);
                    ctNextButton.gameObject.SetActive(true);
                    ctTextBG.gameObject.SetActive(true);
                    ctNext = 1;
                }
                if (!activateFirstText && ctNext == 2)
                {
                    Time.timeScale = 1f;
                    ctText1.gameObject.SetActive(false);
                    ctNextButton.gameObject.SetActive(false);
                    ctTextBG.gameObject.SetActive(false);
                    activateFirstText = true;
                    ctTimer = 0;
                }
                if (activateFirstText && activateSecondText) 
                {
                    ctTimer += 1 * Time.deltaTime;
                }
                if (activateSecondText && ctTimer >= 1f && ctTimer < 1.05f)
                {
                    //Time.timeScale = 0.05f;
                    ctText2.gameObject.SetActive(true);
                    ctNextButton.gameObject.SetActive(true);
                    ctTextBG.gameObject.SetActive(true);
                    ctNext = 3;
                }
                if (activateSecondText && ctNext == 4)
                {
                    Time.timeScale = 1f;
                    ctText2.gameObject.SetActive(false);
                    ctNextButton.gameObject.SetActive(false);
                    ctTextBG.gameObject.SetActive(false);
                    endTexts = true;
                }
                if (endTexts) 
                {
                    ctTimer = 0;
                }
            }
            //print(scTimer);
        }
        
    }

    public void nextTextEvent()
    {
        if (tutorialOnce)
        {
            //////rear brake
            if (safteyFeature.autoRearBrakeTrigger) 
            {
                if (rbNext == 3 && firstBraked)
                {
                    Time.timeScale = 1f;
                    rbText3.gameObject.SetActive(false);
                    rbNextButton.gameObject.SetActive(false);
                    rbTextBG.gameObject.SetActive(false);
                    rbLastTextActivate = true;
                    rbNext = 0;
                }
                if (firstBraked && rbNext == 2)
                {
                    Time.timeScale = 1f;
                    rbText2.gameObject.SetActive(false);
                    rbNextButton.gameObject.SetActive(false);
                    rbTextBG.gameObject.SetActive(false);
                    rbNext = 3;
                }
                if (!onSceneLoad && rbNext == 0)
                {
                    Time.timeScale = 1f;
                    rbText1.gameObject.SetActive(false);
                    rbNextButton.gameObject.SetActive(false);
                    rbTextBG.gameObject.SetActive(false);
                    onSceneLoad = true;
                    rbTimer = 0;
                    rbNext = 1;
                }
            }
            //cross traffic alert
            if (safteyFeature.crossTrafficTrigger) 
            {
                if (ctNext == 4)
                {
                    ctNext = 5;
                }
                if (ctNext == 3)
                {
                    ctNext = 4;
                }
                if (ctNext == 2)
                {
                    ctNext = 3;
                }
                if (ctNext == 1)
                {
                    ctNext = 2;
                }
            }
            //supercruise
            if (safteyFeature.isSuperCruise) 
            {
                if (scNext == 3)
                {
                    scNext = 4;
                }
                if (scNext == 2)
                {
                    scNext = 3;
                }
                if (scNext == 1)
                {
                    scNext = 2;
                }
                if (scNext == 0)
                {
                    scNext = 1;
                }
            }
            
        }

        if (!tutorialOnce && tutorialNext == 3)
        {
            steeringWheelText.gameObject.SetActive(false);
            steeringArrow.gameObject.SetActive(false);
            tutorialTextBG.gameObject.SetActive(false);
            tutorialNextButton.gameObject.SetActive(false);
            Time.timeScale = 1f;
            tutorialtTimer = 0;
            tutorialOnce = true;
            tutorialNext = 0;
        }
        if (!tutorialOnce && tutorialNext == 2)
        {
            brakeGasArrow.gameObject.SetActive(false);
            brakeGasText.gameObject.SetActive(false);
            steeringWheelText.gameObject.SetActive(true);
            steeringArrow.gameObject.SetActive(true);
            tutorialNext = 3;
        }
        if (!tutorialOnce && tutorialNext == 1) 
        {
            gearText.gameObject.SetActive(false);
            gearArrow.gameObject.SetActive(false);
            brakeGasArrow.gameObject.SetActive(true);
            brakeGasText.gameObject.SetActive(true);
            tutorialNext = 2;
        }

        
    }
}

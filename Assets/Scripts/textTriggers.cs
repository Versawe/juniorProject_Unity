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

    //rearBrake UI
    public GameObject rearBrakeMain;
    public TextMeshProUGUI rbText1;
    public TextMeshProUGUI rbText2;
    public TextMeshProUGUI rbText3;

    //crossTraffic UI
    public GameObject crossTrafficMain;
    public TextMeshProUGUI ctText1;
    public TextMeshProUGUI ctText2;

    //activate variables
    public static bool tutorialOnce = false; // skips tutorial if true
    private float tutorialtTimer = 0;
    private float tutorialNext = 0;
    
    private float scTimer = 0;
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

    private float ctTimer = 0;
    public static bool activateFirstText = false;
    public static bool activateSecondText = false;
    public static bool endTexts = false;


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
                if (!justStarted)
                {
                    scTimer += 1 * Time.deltaTime;
                    if (scTimer > 3f && scTimer < 3.30f)
                    {
                        Time.timeScale = 0.05f;
                        scText1.gameObject.SetActive(true);
                        scArrow.gameObject.SetActive(true);
                    }
                    if (scTimer >= 3.40f && scTimer < 3.70f)
                    {
                        Time.timeScale = 1f;
                        scText1.gameObject.SetActive(false);
                        scArrow.gameObject.SetActive(false);
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
                    if (firstActivated && scTimer > 1f && scTimer < 1.40f)
                    {
                        Time.timeScale = 0.05f;
                        scText2.gameObject.SetActive(true);
                    }
                    if (scTimer >= 1.40f && scTimer < 1.70f)
                    {
                        Time.timeScale = 1f;
                        scText2.gameObject.SetActive(false);
                        scTimer = 0;
                        firstActivated2 = true;
                    }
                }

                if (firstActivated2 && firstWheelMovement)
                {
                    scTimer += 1 * Time.deltaTime;
                    if (scTimer > 1f && scTimer < 1.30f) 
                    {
                        Time.timeScale = 0.05f;
                        scText3.gameObject.SetActive(true);
                    }
                    if (scTimer >= 1.30f && scTimer < 1.60f)
                    {
                        Time.timeScale = 1f;
                        scText3.gameObject.SetActive(false);
                    }
                    if (scTimer >= 5.30f && scTimer < 5.60f)
                    {
                        Time.timeScale = 0.05f;
                        scText4.gameObject.SetActive(true);
                    }
                    if (scTimer >= 5.60f && scTimer < 5.90f)
                    {
                        Time.timeScale = 1f;
                        scText4.gameObject.SetActive(false);
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
                if (!onSceneLoad && rbTimer >= 3f && rbTimer <= 3.30f) 
                {
                    Time.timeScale = 0.05f;
                    rbText1.gameObject.SetActive(true);
                }
                if (!onSceneLoad && rbTimer > 3.30f)
                {
                    Time.timeScale = 1f;
                    rbText1.gameObject.SetActive(false);
                    onSceneLoad = true;
                    rbTimer = 0;
                }

                if (onSceneLoad && firstBraked) 
                {
                    rbTimer += 1 * Time.deltaTime;
                }
                if (firstBraked && onSceneLoad && rbTimer >= 1f && rbTimer < 1.30f) 
                {
                    Time.timeScale = 0.05f;
                    rbText2.gameObject.SetActive(true);
                }
                if (firstBraked && onSceneLoad && rbTimer >= 1.30f && rbTimer < 1.60f)
                {
                    Time.timeScale = 1f;
                    rbText2.gameObject.SetActive(false);
                }
                if (firstBraked && onSceneLoad && rbTimer >= 5.0f && rbTimer < 5.30f)
                {
                    Time.timeScale = 0.05f;
                    rbText3.gameObject.SetActive(true);
                }
                if (firstBraked && onSceneLoad && rbTimer >= 5.3f && rbTimer < 5.60f)
                {
                    Time.timeScale = 1f;
                    rbText3.gameObject.SetActive(false);
                    rbLastTextActivate = true;
                }
                if (rbLastTextActivate) 
                {
                    rbTimer = 0;
                }
            }

            //cross traffic text HERE
            if (safteyFeature.crossTrafficTrigger && !pauseFunction.isPaused) 
            {
                if(!activateFirstText) 
                {
                    ctTimer += 1 * Time.deltaTime;
                }
                if (!activateFirstText && ctTimer >= 3f && ctTimer < 3.30f) 
                {
                    Time.timeScale = 0.05f;
                    ctText1.gameObject.SetActive(true);
                }
                if (!activateFirstText && ctTimer >= 3.30f)
                {
                    Time.timeScale = 1f;
                    ctText1.gameObject.SetActive(false);
                    activateFirstText = true;
                    ctTimer = 0;
                }
                if (activateFirstText && activateSecondText) 
                {
                    ctTimer += 1 * Time.deltaTime;
                }
                if (activateSecondText && ctTimer >= 1f && ctTimer < 1.35f)
                {
                    Time.timeScale = 0.05f;
                    ctText2.gameObject.SetActive(true);
                }
                if (activateSecondText && ctTimer >= 1.35f)
                {
                    Time.timeScale = 1f;
                    ctText2.gameObject.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class pauseFunction : MonoBehaviour
{
    public TextMeshProUGUI pauseText;
    public Image resumeButton;
    public Image exitButton;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseText.gameObject.SetActive(false);
        //pauseTextShadow.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseUIActive()
    {
        isPaused = true;
        pauseText.gameObject.SetActive(true);
        //pauseTextShadow.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void pauseUIOFF()
    {
        isPaused = false;
        pauseText.gameObject.SetActive(false);
        //pauseTextShadow.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void exit2Menu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

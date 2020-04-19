using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class pauseFunction : MonoBehaviour
{
    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI pauseTextShadow;
    public Image resumeButton;
    public Image exitButton;

    // Start is called before the first frame update
    void Start()
    {
        pauseText.gameObject.SetActive(false);
        pauseTextShadow.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseUIActive()
    {
        pauseText.gameObject.SetActive(true);
        pauseTextShadow.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void pauseUIOFF()
    {
        pauseText.gameObject.SetActive(false);
        pauseTextShadow.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void exit2Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class loadLevelScene : MonoBehaviour
{
    public TextMeshProUGUI loadingShadow;
    public TextMeshProUGUI loadingText;

    // Start is called before the first frame update
    void Start()
    {
        loadingShadow.gameObject.SetActive(false);
        loadingText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches) 
         {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "button1")
                {
                    loadingScene();
                    SceneManager.LoadScene(1);
                }
                if (hit.collider.name == "button2")
                {
                    loadingScene();
                    SceneManager.LoadScene(2);
                }
                if (hit.collider.name == "button3")
                {
                    loadingScene();
                    SceneManager.LoadScene(3);
                }

            }
            
            
        }

    }

    public void loadingScene()
    {
        loadingShadow.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
    }

}

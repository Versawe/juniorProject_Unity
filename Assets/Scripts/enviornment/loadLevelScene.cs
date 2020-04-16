using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevelScene : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches) 
         {
            if(touch.position.x < Screen.width) 
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.name == "button1") 
                    {
                        SceneManager.LoadScene(1);
                    }
                    if (hit.collider.name == "button2")
                    {
                        SceneManager.LoadScene(2);
                    }
                    if (hit.collider.name == "button3")
                    {
                        SceneManager.LoadScene(3);
                    }

                }
            }
            
        }

    }

}

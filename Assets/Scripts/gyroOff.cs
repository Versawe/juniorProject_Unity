using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gyroOff : MonoBehaviour
{
    public Image gyroBro;

    public static bool boolBro = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!boolBro)
        {
            gyroBro.gameObject.SetActive(true);
        }
        else
        {
            gyroBro.gameObject.SetActive(false);
        }
    }

    public void functionBro()
    {
        if (!boolBro)
        {
            boolBro = true;
        }
        else
        {
            boolBro = false;
        }
    }
}

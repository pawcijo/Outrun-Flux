using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
    public float tajmuu;
 


    // Use this for initialization
    void Start () {
        timer.GetComponent<Text>().text = tajmuu.ToString();
       
    }
	
	// Update is called once per frame
	void Update () {


    

        if (tajmuu > 0.1)
        {
            tajmuu -= Time.deltaTime;
            timer.GetComponent<Text>().text = tajmuu.ToString("F2");
        }
        else
        {
            tajmuu = 0;
            timer.GetComponent<Text>().text = tajmuu.ToString("F2");
        }

       

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1 : MonoBehaviour {

    float tajmuu;
    public Canvas main;
    public Canvas Game;


    // Use this for initialization
    void Start () {
        tajmuu = 0;

    }
	
	// Update is called once per frame
	void Update () {
        tajmuu += Time.deltaTime;

        if(tajmuu>10.0f)
        {
            main.enabled = true;
            Game.enabled = false;
           

        }


    }
}

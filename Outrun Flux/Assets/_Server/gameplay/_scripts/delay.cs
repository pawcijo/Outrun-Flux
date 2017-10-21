using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delay : MonoBehaviour
{
    bool playing = false;
    float timer;
    // Use this for initialization

     void Start()
    {
        GetComponent<AudioSource>().Stop();
    }
    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        if (timer > 2.00f && !playing)
        {
            GetComponent<AudioSource>().Play();
            playing = true;
        }
           

    }
}

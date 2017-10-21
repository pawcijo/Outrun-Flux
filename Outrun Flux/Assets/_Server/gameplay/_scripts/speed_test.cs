using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed_test : MonoBehaviour {

    // Use this for initialization
    private float speed = 20;
    public float BPM = 120;

    //private void Start()
    //{
    //    speed = BPM / 6.0f;
    //}
    // Update is called once per frame
    void Update () {
        if(gameObject.transform.position.z <=0)
        {
            gameObject.transform.Translate(0, 0, 40);
        }

        gameObject.transform.Translate(0, 0, -speed * Time.deltaTime);

		
	}

    public void setBPM(float bpm)
    {
        speed = bpm / 6.0f;
    }
}

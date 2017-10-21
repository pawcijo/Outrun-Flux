using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour {

   
    public float speed;
    public float BPM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(0, 0, -speed * Time.deltaTime);
    }

    public void setBPM(float bpm)
    {
        BPM = bpm;
        speed = bpm / 6.0f;
    }
}

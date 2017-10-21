using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed_test_master : MonoBehaviour {
    public float BPM = 120;
    public List<GameObject> tests;
	// Use this for initialization
	void Start () {
        int i = 0;
        foreach (GameObject t in tests)
        {
            t.GetComponent("speed_test").SendMessage("setBPM",BPM);

            
            Debug.Log(i++);
        }
	}
	
    
	// Update is called once per frame

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
      
	}
	
	public void scale(float scale)
    {
        gameObject.transform.localScale += new Vector3(0.0f, 0.0f, scale);
        gameObject.transform.Translate(new Vector3(0.0f, 0.0f, scale / 2.0f));
    }

   
}

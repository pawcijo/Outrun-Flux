using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wtyczka : MonoBehaviour {

    float czasel = 0.0f;
    bool weszlo = false;
    public Rigidbody2D zmiennarg;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

        if(weszlo==true)
        {
            czasel += Time.deltaTime;
        }

        
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Wtyczka"))
        {
           // Destroy(other.gameObject);
           
            if (czasel >= 0.55f)
            {
                this.GetComponent<Image>().color = new Color(0, 255, 0, 100);
                
                Debug.Log("Siedzi  2s");
                other.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

                // Destroy(other.gameObject);
            }


        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Wtyczka"))
        {
            weszlo = true;
            Debug.Log("Weszlo");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Wtyczka"))
        {
            weszlo = false;
            czasel = 0;
            other.attachedRigidbody.constraints = RigidbodyConstraints2D.None;
            Debug.Log("Wyszlo");
        }

    }


}

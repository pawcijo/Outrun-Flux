using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    public Material red;
    public Material green;

    private bool redd = true;
   
	public void setGreen()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material = green;
        
    }

    public void setRed()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material = red;
    }

   public void change()
    {
        if (redd)
        {
            setGreen();
            redd = false;
        }
        else
        {
            setRed();
            redd = true;
        }
            
        
    }
}

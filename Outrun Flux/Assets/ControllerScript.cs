using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

    private ButtonScript button1;
    private ButtonScript button2;
    private ButtonScript button3;
    private ButtonScript button4;
    // Use this for initialization
    void Start () {
        button1 = gameObject.transform.GetChild(0).GetComponent<ButtonScript>();
        button2 = gameObject.transform.GetChild(1).GetComponent<ButtonScript>();
        button3 = gameObject.transform.GetChild(2).GetComponent<ButtonScript>();
        button4 = gameObject.transform.GetChild(3).GetComponent<ButtonScript>();
    }

    // Update is called once per frame
    public void LU(bool state)
    {
        button1.setButtonState(state);
    }

    public void RU(bool state)
    {
        button4.setButtonState(state);
    }
    public void LD(bool state)
    {
        button2.setButtonState(state);
    }
    public void RD(bool state)
    {
        button3.setButtonState(state);
    }
}

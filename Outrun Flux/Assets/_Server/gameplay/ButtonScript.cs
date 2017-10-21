using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    GameObject gameMaster;

    private Color standard_color;
    public Color custom_color;
    public string input;
    // Use this for initialization
    void Start()
    {
        standard_color = gameObject.GetComponent<Renderer>().material.color;
        gameMaster = GameObject.Find("gameMaster");
        gameMaster.SendMessage("addPoints", 1);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(input))
        {
            gameObject.GetComponent<Renderer>().material.color = custom_color;
        }
        // gameMaster.SendMessage("addPoints")
        else if (Input.GetKeyUp(input))
        {
            gameObject.GetComponent<Renderer>().material.color = standard_color;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(input))
        {
            gameMaster.SendMessage("addPoints", 1);

        }
    }
}

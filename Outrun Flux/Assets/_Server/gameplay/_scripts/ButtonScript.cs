using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    GameObject gameMaster;

    public Color standard_color;
    public Color custom_color;
    public string input;
    private bool isPressed = false;

    private Renderer renderer;
    // Use this for initialization
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = standard_color;
        gameMaster = GameObject.Find("gameMaster");
        gameMaster.SendMessage("addPoints", 1);
    }

    // Update is called once per frame
    void Update()
    {

        if (isPressed)
        {
            renderer.material.color = custom_color;
        }
        // gameMaster.SendMessage("addPoints")
        else
        {
            renderer.material.color = standard_color;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isPressed)
        {
            gameMaster.SendMessage("addPoints", 1);

        }
    }

    public void setButtonState(bool state)
    {
        isPressed = state;
    }
   
}

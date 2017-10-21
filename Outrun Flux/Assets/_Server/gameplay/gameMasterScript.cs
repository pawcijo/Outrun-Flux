using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMasterScript : MonoBehaviour
{

    int points = 0;

    public Text points_text;
    // Use this for initialization
    void Start()
    {

        points_text.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addPoints(int p)
    {
        points += p;
        points_text.text = points.ToString();

    }
}

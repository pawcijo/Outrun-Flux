using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMasterScript : MonoBehaviour
{

    public float BPM = 120;
    public GameObject note;
    public bool isActive = false;
    //  public float units_per_beat = 10;

    GameObject[] gameobjarray = new GameObject[4];
    float[] lenghts = new float[4];

    void Start()
    {
        if (!isActive)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameobjarray[0] = Instantiate(note, new Vector3(-3.25f, 2.0f, 0.0f), Quaternion.identity);
            gameobjarray[0].GetComponent("NoteScript").SendMessage("setBPM", BPM);
            lenghts[0] = 0.0f;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            lenghts[0] = Mathf.Abs(gameobjarray[0].transform.position.z);
            if (lenghts[0] > 2.5)
                gameobjarray[0].GetComponent("NoteScaler").SendMessage("scale", lenghts[0]);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            gameobjarray[1] = Instantiate(note, new Vector3(-1.25f, 2.0f, 0.0f), Quaternion.identity);
            gameobjarray[1].GetComponent("NoteScript").SendMessage("setBPM", BPM);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            lenghts[1] = Mathf.Abs(gameobjarray[1].transform.position.z);
            if (lenghts[1] > 2.5)
                gameobjarray[1].GetComponent("NoteScaler").SendMessage("scale", lenghts[1]);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            gameobjarray[2] = Instantiate(note, new Vector3(1.25f, 2.0f, 0.0f), Quaternion.identity);
            gameobjarray[2].GetComponent("NoteScript").SendMessage("setBPM", BPM);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            lenghts[2] = Mathf.Abs(gameobjarray[2].transform.position.z);
            if (lenghts[2] > 2.5)
                gameobjarray[2].GetComponent("NoteScaler").SendMessage("scale", lenghts[2]);
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            gameobjarray[3] = Instantiate(note, new Vector3(3.25f, 2.0f, 0.0f), Quaternion.identity);
            gameobjarray[3].GetComponent("NoteScript").SendMessage("setBPM", BPM);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            lenghts[3] = Mathf.Abs(gameobjarray[3].transform.position.z);
            if (lenghts[3] > 2.5)
                gameobjarray[3].GetComponent("NoteScaler").SendMessage("scale", lenghts[3]);
        }

    }
}

using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour
{

    Ray ray;
    RaycastHit2D hit;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Debug.Log("touched!");
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                //Debug.DrawRay(ray.origin, ray.direction * 5000.0f, Color.red);
               // hit = null;
                

                if (Physics2D.Raycast(ray.origin, ray.direction))
                {
                    hit = Physics2D.Raycast(ray.origin, ray.direction);
                    Debug.Log("Hit!");

                    hit.transform.gameObject.SendMessage("OnHit");

                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWarRight : MonoBehaviour
{
    private float timer = 0.0f;
    public bool ClosingWardoor = false;
    [SerializeField]
    OpenWarRight openWarRight;
    [SerializeField]
    CloseWarRight closeWarRight;

    [SerializeField]
    GameObject WardrobeHolderRight;

    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
            {
            // print("ClosingDoor");
            ClosingWardoor = true;
            }
        
    }

    private void Start()
    {
        GameObject varGameObject = GameObject.Find("RightKnob");
        varGameObject.GetComponent<CloseWarRight>().enabled = true;
        varGameObject.GetComponent<OpenWarRight>().enabled = false;
        ClosingWardoor = false;
    }

    public void Update()
    {
        if (ClosingWardoor == true)
        {
            //print("RotatingClosingDoor");
            if (WardrobeHolderRight.transform.rotation.eulerAngles.y > -90) //-90
            {

                WardrobeHolderRight.transform.Rotate(0.0f, -90 * Time.deltaTime, 0.0f); //-180.0f
            }
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                ClosingWardoor = false;
                //  print("FinishedRotatingClosingDoor");
                GameObject varGameObject = GameObject.Find("RightKnob");
                varGameObject.GetComponent<OpenWarRight>().enabled = true;
                varGameObject.GetComponent<CloseWarRight>().enabled = false;



            }


        }
    }
}

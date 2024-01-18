using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWarRight : MonoBehaviour
{
    private float timer = 0.0f;
    public bool OpeningWardoor = false;
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
                //print("OpeningDoor");
                OpeningWardoor = true;
            }
        
    }

    private void Start()
    {
        GameObject varGameObject = GameObject.Find("RightKnob");
        varGameObject.GetComponent<OpenWarRight>().enabled = true;
        varGameObject.GetComponent<CloseWarRight>().enabled = false;
        OpeningWardoor = false;
    }

    public void Update()
    {
        if (OpeningWardoor == true)
        {
            //print("RotatingOpeningDoor");
            if (WardrobeHolderRight.transform.rotation.eulerAngles.z < 90) // yr = 90f
            {
                WardrobeHolderRight.transform.Rotate(0.0f, 90f * Time.deltaTime, 0.0f); // yR = 90f

            }
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                OpeningWardoor = false;
                //print("FinishedRotatingOpeningDoor");
                GameObject varGameObject = GameObject.Find("RightKnob");
                varGameObject.GetComponent<CloseWarRight>().enabled = true;
                varGameObject.GetComponent<OpenWarRight>().enabled = false;


            }


        }
    }
}

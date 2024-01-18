using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWarLeft : MonoBehaviour
{
    private float timer = 0.0f;
    public bool OpeningWardoor = false;
    [SerializeField]
    OpenWarLeft openWarLeft;
    [SerializeField]
    CloseWarLeft closeWarLeft;

    [SerializeField]
    GameObject WardrobeHolderLeft;



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
        GameObject varGameObject = GameObject.Find("LeftKnob");
        varGameObject.GetComponent<OpenWarLeft>().enabled = true;
        varGameObject.GetComponent<CloseWarLeft>().enabled = false;
        OpeningWardoor = false;
    }

    public void Update()
    {
        if (OpeningWardoor == true)
        {
            //print("RotatingOpeningDoor");
            if (WardrobeHolderLeft.transform.rotation.eulerAngles.z > -90) // yr = 90f
            {
                WardrobeHolderLeft.transform.Rotate(0.0f, -90f * Time.deltaTime, 0.0f); // yR = 90f

            }
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                OpeningWardoor = false;
                //print("FinishedRotatingOpeningDoor");
                GameObject varGameObject = GameObject.Find("LeftKnob");
                varGameObject.GetComponent<CloseWarLeft>().enabled = true;
                varGameObject.GetComponent<OpenWarLeft>().enabled = false;


            }


        }
    }
}

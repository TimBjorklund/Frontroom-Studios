using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWarLeft : MonoBehaviour
{
    private float timer = 0.0f;
    public bool ClosingWardoor = false;
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
            // print("ClosingDoor");
            ClosingWardoor = true;
        }

    }

    private void Start()
    {
        GameObject varGameObject = GameObject.Find("LeftKnob");
        varGameObject.GetComponent<CloseWarLeft>().enabled = true;
        varGameObject.GetComponent<OpenWarLeft>().enabled = false;
        ClosingWardoor = false;
    }

    public void Update()
    {
        if (ClosingWardoor == true)
        {
            //print("RotatingClosingDoor");
            if (WardrobeHolderLeft.transform.rotation.eulerAngles.y > 90) //-90
            {

                WardrobeHolderLeft.transform.Rotate(0.0f, 90 * Time.deltaTime, 0.0f); //-180.0f
            }
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                ClosingWardoor = false;
                //  print("FinishedRotatingClosingDoor");
                GameObject varGameObject = GameObject.Find("LeftKnob");
                varGameObject.GetComponent<OpenWarLeft>().enabled = true;
                varGameObject.GetComponent<CloseWarLeft>().enabled = false;



            }


        }
    }
}

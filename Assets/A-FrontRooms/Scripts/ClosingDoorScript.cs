using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoorScript : MonoBehaviour
{
    private float timer = 0.0f;
    private float nextscripttimer = 0.0f;
    public bool Closingdoor = false;
    [SerializeField]
    OpeningDoorScript openingDoorScript;
    [SerializeField]
    ClosingDoorScript closingDoorScript;
    [SerializeField]
    KeyHoleScript keyholescript;

    [SerializeField]
    GameObject Doorholder;
    [SerializeField]
    GameObject HandleCombined;

    [SerializeField]
    float xR;
    [SerializeField]
    float yR;
    [SerializeField]
    float zR;

    void OnCollisionEnter(Collision collision)
    {
        if (keyholescript.Unlocked == true)
        {
            if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
            {
               // print("ClosingDoor");
                Closingdoor = true;
            }
        }
    }

    private void Start()
    {
        GameObject varGameObject = GameObject.Find("HandleCombined");
        varGameObject.GetComponent<OpeningDoorScript>().enabled = false;
        //varGameObject.GetComponent<ClosingDoorScript>().enabled = true;
        // varGameObject.GetComponent<OpeningDoorScript>().enabled = false;
        Closingdoor = false;
        HandleCombined.SetActive(true); 

    }

    public void Update()
    {
        if (Closingdoor == true)
        {
            //print("RotatingClosingDoor");
            if (Doorholder.transform.rotation.eulerAngles.y > -90) //-90
            {
              
                Doorholder.transform.Rotate(xR, -90 * Time.deltaTime, zR); //-180.0f
            }
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                Closingdoor = false;
              //  print("FinishedRotatingClosingDoor");
                GameObject varGameObject = GameObject.Find("HandleCombined");
                varGameObject.GetComponent<OpeningDoorScript>().enabled = true;
                nextscripttimer += Time.deltaTime;
                if (nextscripttimer >= 1.0f)
                {
                    HandleCombined.SetActive(false);
                }


            }


        }
    }
}

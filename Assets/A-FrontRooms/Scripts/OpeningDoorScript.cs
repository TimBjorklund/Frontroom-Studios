using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoorScript : MonoBehaviour
{
    private float timer = 0.0f;
    public bool Openingdoor = false;
    [SerializeField]
    OpeningDoorScript openingDoorScript;
    [SerializeField]
    ClosingDoorScript closingDoorScript;
    [SerializeField]
    KeyHoleScript keyholescript;

    [SerializeField]
    GameObject Doorholder;

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
               //print("OpeningDoor");
              Openingdoor = true;
            }
        }
    }

    private void Start()
    {
        GameObject varGameObject = GameObject.Find("HandleCombined");
        varGameObject.GetComponent<OpeningDoorScript>().enabled = true;
        varGameObject.GetComponent<ClosingDoorScript>().enabled = false;
        Openingdoor = false;
    }

    public void Update()
    {
        if (Openingdoor == true)
        {
            //print("RotatingOpeningDoor");
            if (Doorholder.transform.rotation.eulerAngles.z < 90) // yr = 90f
            {
                Doorholder.transform.Rotate(xR, 90f * Time.deltaTime, zR); // yR = 90f

            }
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                Openingdoor = false;
                //print("FinishedRotatingOpeningDoor");
                GameObject varGameObject = GameObject.Find("HandleCombined");
                varGameObject.GetComponent<ClosingDoorScript>().enabled = true;
                varGameObject.GetComponent<OpeningDoorScript>().enabled = false;
               

            }


        }
    }
}

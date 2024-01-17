using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScript : MonoBehaviour
{
    [SerializeField]
    GameObject Doorholder;

    [SerializeField]
    float xR;
    [SerializeField]
    float yR;
    [SerializeField]
    float zR;

    public bool openingdoor = false;

 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Test")
        {
            print("Dorhandlehit2");
        }
        if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
        {
            openingdoor = true;
            print("Doorhandlehit");
            if(openingdoor == true)
            {
                if (Doorholder.transform.rotation.eulerAngles.z < yR) //90
                {
                    Doorholder.transform.Rotate(xR, yR * Time.deltaTime, zR); //180.0f
                    openingdoor = false;
                }
            }
             if(openingdoor == false && collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
            {
                if (Doorholder.transform.rotation.eulerAngles.z < -yR) //-90
                {
                    Doorholder.transform.Rotate(xR, -yR * Time.deltaTime, zR); //-180.0f
                }
            }
            

        }
    }
}

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
    public bool closingdoor = false;
    [SerializeField]
    KeyHoleScript keyholescript;

    private void Start()
    {
        //keyholescript = GetComponent<KeyHoleScript>();
    }
    void OnCollisionEnter(Collision collision)
    {


       if (keyholescript.Unlocked == true)
       {
            if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
            {
                openingdoor = true;
                print("Doorhandlehit");

                    
            }
                if (openingdoor == false && collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
                {
                openingdoor = false;
                }
       }
     }

    public void Update()
    {
        if(openingdoor == true)
        {
            if(Doorholder.transform.rotation.eulerAngles.z < yR) // yr = 90f
            {
                Doorholder.transform.Rotate(xR, yR * Time.deltaTime, zR); // yR = 90f

            }
            
        }
        if(closingdoor == true)
        {
            if (Doorholder.transform.rotation.eulerAngles.z < -yR) //-90
            {
                Doorholder.transform.Rotate(xR, -yR * Time.deltaTime, zR); //-180.0f
            }
        }
    }
}



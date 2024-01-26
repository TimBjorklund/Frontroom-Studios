using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;

public class KeyHoleScript : MonoBehaviour
{

    [SerializeField]
    XRSocketInteractor socket;

    [SerializeField]
    GameObject Doorholder;
    [SerializeField]
    GameObject Lock;



    [SerializeField]
    private float  floorPoint;

    public bool Unlocked = false;

    public bool rightKey;

    void Update()
    {

        //Om specfik nyckelnamn socketerar med specfik l�snamn d�, g�r bla bla bla
        if (Lock == null)
        {
            Unlocked = true;
        }
 
      
        if (socket.hasHover)
        {
            {
                Unlocked = true;
                if (Lock.transform.position.y > floorPoint)
                {
                    Vector3 temp = new Vector3(0, 3f * Time.deltaTime, 0);
                    Lock.transform.position -= temp;
                }
                if (Lock.transform.rotation.eulerAngles.z < 90) //90
                {
                    Lock.transform.Rotate(0f, 0f, 180.0f * Time.deltaTime); //180.0f
                }
            }
          


            //OpenDoor();
        }
    }
    
    /*
    public void OpenDoor()
    {
        if (Doorholder.transform.rotation.eulerAngles.y < yR) //90
        {
            Doorholder.transform.Rotate(xR, yR * Time.deltaTime, zR);  //90.0f
        }
        
    }
    */



}

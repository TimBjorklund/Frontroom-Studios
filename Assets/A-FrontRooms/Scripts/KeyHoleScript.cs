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
    GameObject rightKey;

    [SerializeField]
    GameObject Doorholder;
    [SerializeField]
    GameObject Lock;

    [SerializeField]
    private float  floorPoint;

    public bool Unlocked = false;


    void Update()
    {

        //Om specfik nyckelnamn socketerar med specfik låsnamn då, gör bla bla bla
        if (rightKey == null)
        {
            Unlocked = true;
        }


        if (socket.hasHover && rightKey == socket.firstInteractableSelected.transform.gameObject) 
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
    }




}

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




    void Update()
    {
        if (socket.hasHover)
        {
            if (Lock.transform.position.y > floorPoint)
            {
                Vector3 temp = new Vector3(0, 3f * Time.deltaTime, 0);
                Lock.transform.position -= temp;
            }
            if (Lock.transform.rotation.eulerAngles.z < 90)
            {
                Lock.transform.Rotate(0.0f, 0.0f, 180.0f * Time.deltaTime);
            }


            OpenDoor();
        }
    }
    

    public void OpenDoor()
    {
        if (Doorholder.transform.rotation.eulerAngles.y < 90)
        {
            Doorholder.transform.Rotate(0.0f, 90.0f * Time.deltaTime, 0.0f);
        }
        
    }




}

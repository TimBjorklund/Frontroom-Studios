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

    private int Openingspeed = 1;

    void Update()
    {
        if (socket.hasHover)
        {
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

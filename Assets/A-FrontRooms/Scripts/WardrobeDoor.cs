using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeDoor : MonoBehaviour
{
    [SerializeField]
    GameObject Wardrobedoorholder;

    public void OpenWardrobeDoor()
    {

        if(gameObject.name == "WardrobeHolderRight")
        {
            if (Wardrobedoorholder.transform.rotation.eulerAngles.x < 90)
            {
                Wardrobedoorholder.transform.Rotate(90.0f * Time.deltaTime, 0.0f, 0.0f);
            }
        }
        else
        {
            if (Wardrobedoorholder.transform.rotation.eulerAngles.x < -90)
            {
                Wardrobedoorholder.transform.Rotate(-90.0f * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Test")
        {
            print("OpeningWardrobe");
            OpenWardrobeDoor();
        }


    }
}

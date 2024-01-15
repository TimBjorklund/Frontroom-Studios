using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeDoor : MonoBehaviour
{
    [SerializeField]
    GameObject Wardrobedoorholderright;

    [SerializeField]
    GameObject Wardrobedoorholderleft;

    public void OpenWardrobeDoor()
    {

        if (Wardrobedoorholderright.transform.rotation.eulerAngles.x < 90)
        {
            Wardrobedoorholderright.transform.Rotate(90.0f * Time.deltaTime, 0.0f, 0.0f);
        }

        else
        {
            if (Wardrobedoorholderleft.transform.rotation.eulerAngles.x < -90)
            {
                Wardrobedoorholderleft.transform.Rotate(-90.0f * Time.deltaTime, 0.0f, 0.0f);
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

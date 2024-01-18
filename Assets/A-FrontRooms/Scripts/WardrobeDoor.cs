using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeDoor : MonoBehaviour
{
    [SerializeField]
    GameObject Wardrobedoorholderright;

    [SerializeField]
    GameObject Wardrobedoorholderleft;

    private bool Opening;
    private void Start()
    {
        Opening = false;
    }
    public void Update()
    {
        if (Opening == true)
        {
            if (gameObject.name == "RightKnob")
            {
                if (Wardrobedoorholderright.transform.rotation.eulerAngles.y < 90)
                {
                    Wardrobedoorholderright.transform.Rotate( 0.0f, 90.0f * Time.deltaTime, 0.0f);
                }
            }
             if (gameObject.name == "LeftKnob")
            {
                if (Wardrobedoorholderleft.transform.rotation.eulerAngles.y > -90)
                {
                    Wardrobedoorholderleft.transform.Rotate( 0.0f, -90.0f * Time.deltaTime, 0.0f);
                }
            }
        }

    }
     
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Test")
        {
            print("OpeningWardrobe");
            Opening = true;
        }


    }
}

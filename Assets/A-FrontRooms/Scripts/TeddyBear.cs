using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;

public class TeddyBear : MonoBehaviour
{


    //Ska kunna fungera f�r 7 texter till 7 teddybj�rnar
    [SerializeField]
    GameObject teddyObject;

    [SerializeField]
    TeddyCounter teddycounter;

    // Start is called before the first frame update
    void Start()
    {

        teddycounter.GetComponent<TeddyCounter>();

    }
        
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Left Controller")
        {
            Destroy(teddyObject);
            teddycounter.CollectBear();
        }
     

    }

}

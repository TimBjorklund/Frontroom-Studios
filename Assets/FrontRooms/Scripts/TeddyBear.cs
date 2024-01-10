using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;

public class TeddyBear : MonoBehaviour
{

    [SerializeField]
    GameObject teddyObject;
    /*
    public int teddyTexter;
    public Text teddyCount;

    public int teddysleft = 7;
    */
    [SerializeField]
    TeddyCounter teddycounter;

    // Start is called before the first frame update
    void Start()
    {

        teddycounter.GetComponent<TeddyCounter>();
        //  teddyCount = GetComponentInChildren<Text>();
       // teddycounter = GetComponent<TeddyCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        teddyTexter = teddysleft;
        teddyCount.text = "" + teddyTexter;

        if (teddysleft == 0)
        {
            //Winner.PNG
        }
        */
    }
        
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Left Controller")
        {
            Destroy(teddyObject); //Förstör också canvas etc....
          //  teddycounter.teddyTexter -= 1;
            teddycounter.teddysleft--;
        }
        if (collision.gameObject.name == "Right Controller")
        {
            Destroy(teddyObject);
         //   teddycounter.teddyTexter -= 1;
            teddycounter.teddysleft--;
        }

    }

}

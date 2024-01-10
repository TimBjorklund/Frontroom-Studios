using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;

public class TeddyCounter : MonoBehaviour
{
    [SerializeField]
    GameObject teddyObject;

    public int teddyTexter;
    public Text teddyCount;

    public int teddysleft = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        teddyTexter = teddysleft;
        teddyCount.text = "" + teddyTexter;

        if (teddysleft == 0)
        {
            //Winner.PNG
        }
    }
}

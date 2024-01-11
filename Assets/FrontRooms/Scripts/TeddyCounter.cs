using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;

public class TeddyCounter : MonoBehaviour
{

    public Text teddyCount;

    public int teddysleft = 7;

    void Update()
    {
        
        teddyCount.text = "" + teddysleft;

        if (teddysleft == 0)
        {
            teddyCount.text = "Winner Winner Kyckling Dinner!";
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Grid_Script : MonoBehaviour
{
    int gridSize = 15;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInterior();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnInterior()
    {
        //x = 0, x = 15, z = 0, z = 15 - det här är vägg slots, när x = 0 så är alla z värden vägg.

        for (int x = 0; x < gridSize; x++) //kanske kan byta ut 0 och 15 med "lowerbound" public variabel och samma för higher bound
        {
            for(int z = 0; z < gridSize; z++) //värdena kommer göra systemet utbyggbart 
            {
                if (x == 0)
                {
                    //spawna vägg möbler med rotation 
                }
                else if (z == 0)
                {
                    //spawna vägg möbler med rotation
                }
                //random chance, = bool något blir true
                //om bool är true, instantiate objekt från en objekt array
            }
        }
    }
}

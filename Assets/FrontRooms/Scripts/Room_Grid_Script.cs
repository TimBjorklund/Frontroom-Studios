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
        //x = 0, x = 15, z = 0, z = 15 - det h�r �r v�gg slots, n�r x = 0 s� �r alla z v�rden v�gg.

        for (int x = 0; x < gridSize; x++) //kanske kan byta ut 0 och 15 med "lowerbound" public variabel och samma f�r higher bound
        {
            for(int z = 0; z < gridSize; z++) //v�rdena kommer g�ra systemet utbyggbart 
            {
                if (x == 0)
                {
                    //spawna v�gg m�bler med rotation 
                }
                else if (z == 0)
                {
                    //spawna v�gg m�bler med rotation
                }
                //random chance, = bool n�got blir true
                //om bool �r true, instantiate objekt fr�n en objekt array
            }
        }
    }
}

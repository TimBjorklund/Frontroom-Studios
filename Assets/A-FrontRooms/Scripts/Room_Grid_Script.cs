using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Grid_Script : MonoBehaviour
{
    public int spawnChanse = 15;

    public int roomSizeX = 15;
    public int roomSizeZ = 15;

    [SerializeField] GameObject[] furniture; GameObject[] wallFurniture;

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

        for (int x = 0; x < roomSizeX; x++) //kanske kan byta ut 0 och 15 med "lowerbound" public variabel och samma f�r higher bound
        {
            for(int z = 0; z < roomSizeX; z++) //v�rdena kommer g�ra systemet utbyggbart 
            {
                var randomSpawn = Random.Range(1, spawnChanse);
                var randomFurniture = Random.Range(0, furniture.Length);
                var randomWallFurniture = Random.Range(0, wallFurniture.Length);

                if (randomSpawn == spawnChanse)
                {
                    if (x == 0 || x == 0 && z == 0)
                    {
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0));
                    }
                    else if (z == 0)
                    {
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 0, 90));
                    }
                    else if (x == roomSizeX)
                    {
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 0, 180));
                    }
                    else if (z == roomSizeZ || z == roomSizeZ && x == roomSizeX)
                    {
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 0, 270));
                    }
                    else
                    {
                        Instantiate(furniture[randomFurniture], new Vector3(x, 0, z), Quaternion.identity);
                        //random chance, = bool n�got blir true
                        //om bool �r true, instantiate objekt fr�n en objekt array

                    }
                }
            }
        }
    }
}

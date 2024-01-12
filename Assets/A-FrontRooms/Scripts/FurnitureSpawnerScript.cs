using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSpawnerScript : MonoBehaviour
{
    public int spawnChanse = 15;

    public int roomSizeX = 15;
    public int roomSizeZ = 15;

    [SerializeField]  
    GameObject[] furniture;
    [SerializeField]
    GameObject[] wallFurniture;
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

        for (int x = 1; x < roomSizeX; x++) //kanske kan byta ut 0 och 15 med "lowerbound" public variabel och samma för higher bound
        {
            for (int z = 1; z < roomSizeZ; z++) //värdena kommer göra systemet utbyggbart 
            {
                Debug.Log("can spawn");
                var randomSpawn = Random.Range(1, spawnChanse);
                var randomFurniture = Random.Range(0, furniture.Length);
                var randomWallFurniture = Random.Range(0, wallFurniture.Length);

                if (randomSpawn == 1)
                {
                    Debug.Log("spawn");
                    if (x == 1 || x == 1 && z == 1)
                    {
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0));
                    }
                    else if (z == 1)
                    {
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 270, 0));
                    }
                    else if (x == roomSizeX - 1)
                    {
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 180, 0));
                    }
                    else if (z == roomSizeZ - 1 || z == roomSizeZ - 1 && x == roomSizeX - 1)
                    {
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 90, 0));
                    }
                    else
                    {
                        Instantiate(furniture[randomFurniture], new Vector3(x, 0, z), Quaternion.identity);
                        //random chance, = bool något blir true
                        //om bool är true, instantiate objekt från en objekt array

                    }
                }
            }
        }
    }
}

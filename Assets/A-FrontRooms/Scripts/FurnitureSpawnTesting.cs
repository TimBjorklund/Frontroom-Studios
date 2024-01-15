using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSpawnTesting : MonoBehaviour
{
    public int spawnChance = 15;

    public int roomSizeX = 15;
    public int roomSizeZ = 15;

    int bShelfX = -10;
    int bShelfZ = -10;

    int randomObjectX = 0;
    int randomobjectZ = 0;

    bool bookShelfSpawned = false;
    bool randomObjectSpawned = false;

    [SerializeField]
    GameObject[] furniture;
    [SerializeField]
    GameObject[] wallFurniture;

    int[,] canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = new int[roomSizeX, roomSizeZ];
        for (int x = 0; x < roomSizeX; x++)
        {
            for (int y = 0; y < roomSizeZ; y++)
            {
                canSpawn[x, y] = 0;
            }
        }
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
                var randomSpawn = Random.Range(1, spawnChance);

                if (randomSpawn == 1)
                {
                    var randomFurniture = Random.Range(0, furniture.Length);
                    var randomWallFurniture = Random.Range(0, wallFurniture.Length);
                    Debug.Log("spawn");

                    if (x == 1 && z == 1 || x == roomSizeX - 1 && z == roomSizeZ - 1 || x == 1 && z == roomSizeZ - 1 || z == 1 && x == roomSizeX - 1)
                    {
                        bookShelfSpawned = true;
                    }
                    else if (bShelfX + 2 < x || bShelfZ + 2 < z)
                    {
                        bookShelfSpawned = false;
                    }

                    if (x == 1 && !bookShelfSpawned || x == 1 && z == 1 && !bookShelfSpawned)
                    {
                        Debug.Log("spawn bookshelf");
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0));
                        if (randomWallFurniture == 0)
                        {
                            bookShelfSpawned = true;
                            bShelfX = x;
                            bShelfZ = z;
                        }
                    }
                    else if (z == 1 && !bookShelfSpawned)
                    {
                        Debug.Log("spawn bookshelf");
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 270, 0));
                        if (randomWallFurniture == 0)
                        {
                            bookShelfSpawned = true;
                            bShelfX = x;
                            bShelfZ = z;
                        }
                    }
                    else if (x == roomSizeX - 1 && !bookShelfSpawned)
                    {
                        Debug.Log("spawn bookshelf");
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 180, 0));
                        if (randomWallFurniture == 0)
                        {
                            bookShelfSpawned = true;
                            bShelfX = x;
                            bShelfZ = z;
                        }
                    }
                    else if (z == roomSizeZ - 1 && !bookShelfSpawned || z == roomSizeZ - 1 && x == roomSizeX - 1 && !bookShelfSpawned)
                    {
                        Debug.Log("spawn bookshelf");
                        Instantiate(wallFurniture[randomWallFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, 90, 0));
                        if (randomWallFurniture == 0)
                        {
                            bookShelfSpawned = true;
                            bShelfX = x;
                            bShelfZ = z;
                        }
                    }
                    else if (x > 1 && x < roomSizeX - 1 && z > 1 && z < roomSizeZ - 1 && canSpawn[x, z] == 0)
                    {
                        var randomRotation = Random.Range(0, 359);
                        Instantiate(furniture[randomFurniture], new Vector3(x, 0, z), Quaternion.Euler(0, randomRotation, 0));
                        randomObjectX = x;
                        randomobjectZ = z;

                        canSpawn[x, z] = 9;
                        canSpawn[x + 1, z] = 9;
                        canSpawn[x - 1, z] = 9;
                        canSpawn[x, z + 1] = 9;
                        canSpawn[x, z - 1] = 9;
                        canSpawn[x + 1, z + 1] = 9;
                        canSpawn[x - 1, z + 1] = 9;
                        canSpawn[x + 1, z - 1] = 9;
                        canSpawn[x - 1, z - 1] = 9;
                    }
                }
            }
        }
    }
}

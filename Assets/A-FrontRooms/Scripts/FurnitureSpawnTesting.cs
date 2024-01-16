using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSpawnTesting : AddedCommands
{
    public int spawnChance = 15;

    public int roomSizeX = 15;
    public int roomSizeZ = 15;
    public int wallHeight = 3;

    int wallLenghtX;
    int wallLenghtZ;

    int wFurnitureX = -10;
    int wFurnitureZ = -10;

    int randomObjectX = 0;
    int randomobjectZ = 0;

    bool wallFurnitureSpawned = false;

    public GameObject wall;

    [SerializeField]
    GameObject[] furniture;
    [SerializeField]
    GameObject[] wallFurniture;

    Vector3 currentLocation;

    int[,] canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        roomSizeX = Random.Range(5,30);
        roomSizeZ = Random.Range(5, 30);

        wallLenghtX = roomSizeX;
        wallLenghtZ = roomSizeZ;

        canSpawn = new int[roomSizeX, roomSizeZ];
        for (int x = 0; x < roomSizeX; x++)
        {
            for (int y = 0; y < roomSizeZ; y++)
            {
                canSpawn[x, y] = 0;
            }
        }
        currentLocation = gameObject.transform.position - new Vector3(roomSizeX / 2, 0, roomSizeZ / 2);
        CreateWalls();
        SpawnInterior();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateWalls()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                for (int wallCount = 0; wallCount < wallLenghtX; wallCount++)
                {
                    GameObject newObject = Instantiate(wall, currentLocation + new Vector3(wallCount, wallHeight / 2, 0 /*gör tunnare väggar, t.ex -0.5, 0.95f*/), Quaternion.identity);
                    newObject.transform.localScale = new Vector3(1, wallHeight, 1.45f);
                    newObject.name = "wallX1 " + wallCount;
                }
            }
            else if (i == 1)
            {
                for (int wallCount = 0; wallCount < wallLenghtZ; wallCount++)
                {
                    GameObject newObject = Instantiate(wall, currentLocation + new Vector3(0, wallHeight / 2, wallCount), Quaternion.identity);
                    newObject.transform.localScale = new Vector3(1, wallHeight, 1.45f);
                    newObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    newObject.name = "wallX2 " + wallCount;
                }
            }
            else if (i == 2)
            {
                for (int wallCount = 0; wallCount < wallLenghtX; wallCount++)
                {
                    GameObject newObject = Instantiate(wall, currentLocation + new Vector3(wallCount, wallHeight / 2, wallLenghtZ), Quaternion.identity);
                    newObject.transform.localScale = new Vector3(1, wallHeight, 1.45f);
                    newObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    newObject.name = "wallX3 " + wallCount;
                }
            }
            else if (i == 3)
            {
                for (int wallCount = 0; wallCount < wallLenghtZ; wallCount++)
                {
                    GameObject newObject = Instantiate(wall, currentLocation + new Vector3(wallLenghtX, wallHeight / 2, wallCount), Quaternion.identity);
                    newObject.transform.localScale = new Vector3(1, wallHeight, 1.45f);
                    newObject.transform.localRotation = Quaternion.Euler(0, 270, 0);
                    newObject.name = "wallX4 " + wallCount;
                }
            }

        }
    }
    void SpawnInterior()
    {
        //x = 0, x = 15, z = 0, z = 15 - det här är vägg slots, när x = 0 så är alla z värden vägg.

        for (int x = 1; x < roomSizeX; x++) //kanske kan byta ut 0 och 15 med "lowerbound" public variabel och samma för higher bound
        {
            for (int z = 1; z < roomSizeZ; z++) //värdena kommer göra systemet utbyggbart 
            {
                Debug.Log("can spawn");
                var randomSpawn = Random.Range(1, 100);

                if (randomSpawn <= spawnChance)
                {
                    var randomFurniture = Random.Range(0, furniture.Length);
                    var randomWallFurniture = Random.Range(0, wallFurniture.Length);
                    Debug.Log("spawn");

                    if (x == 1 && z == 1 || x == roomSizeX - 1 && z == roomSizeZ - 1 || x == 1 && z == roomSizeZ - 1 || z == 1 && x == roomSizeX - 1)
                    {
                        wallFurnitureSpawned = true;
                    }
                    else if (wFurnitureX + 2 < x || wFurnitureZ + 2 < z)
                    {
                        wallFurnitureSpawned = false;
                    }

                    if (x == 1 && !wallFurnitureSpawned || x == 1 && z == 1 && !wallFurnitureSpawned)
                    {
                        ImprovedInstantiate(wallFurniture[randomWallFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, 0, 0));
                            wallFurnitureSpawned = true;
                            wFurnitureX = x;
                            wFurnitureZ = z;
                    }
                    else if (z == 1 && !wallFurnitureSpawned)
                    {
                        ImprovedInstantiate(wallFurniture[randomWallFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, 270, 0));
                            wallFurnitureSpawned = true;
                            wFurnitureX = x;
                            wFurnitureZ = z;
                    }
                    else if (x == roomSizeX - 1 && !wallFurnitureSpawned)
                    {
                        ImprovedInstantiate(wallFurniture[randomWallFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, 180, 0));
                            wallFurnitureSpawned = true;
                            wFurnitureX = x;
                            wFurnitureZ = z;
                    }
                    else if (z == roomSizeZ - 1 && !wallFurnitureSpawned || z == roomSizeZ - 1 && x == roomSizeX - 1 && !wallFurnitureSpawned)
                    {
                        ImprovedInstantiate(wallFurniture[randomWallFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, 90, 0));
                            wallFurnitureSpawned = true;
                            wFurnitureX = x;
                            wFurnitureZ = z;
                    }
                    else if (x > 1 && x < roomSizeX - 1 && z > 1 && z < roomSizeZ - 1 && canSpawn[x, z] == 0)
                    {
                        var randomRotation = Random.Range(0, 359);
                        ImprovedInstantiate(furniture[randomFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, randomRotation, 0));
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

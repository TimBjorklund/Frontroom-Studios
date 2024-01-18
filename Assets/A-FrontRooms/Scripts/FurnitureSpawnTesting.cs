using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSpawnTesting : AddedCommands
{
    public int spawnChance = 15;

    public float roomSizeX;
    public float roomSizeZ;
    public int wallHeight = 3;

    float wallLenghtX;
    float wallLenghtZ;

    int lampCount = 0;

    int wFurnitureX = -10;
    int wFurnitureZ = -10;

    public GameObject floor;
    public GameObject wall;

    public GameObject lamp;
    [SerializeField]
    GameObject[] furniture;
    [SerializeField]
    GameObject[] wallFurniture;

    Vector3 currentLocation;

    float[,] canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        /*
        roomSizeX = Random.Range(7,30);
        roomSizeZ = Random.Range(7, 30);
        */
        roomSizeX = gameObject.transform.localScale.x;
        roomSizeZ = gameObject.transform.localScale.z;

        wallLenghtX = roomSizeX;
        wallLenghtZ = roomSizeZ;

        canSpawn = new float[(int)roomSizeX, (int)roomSizeZ];
        for (int x = 0; x < roomSizeX; x++)
        {
            for (int y = 0; y < roomSizeZ; y++)
            {
                canSpawn[x, y] = 0;
            }
        }
        currentLocation = gameObject.transform.position - new Vector3(roomSizeX / 2, 0, roomSizeZ / 2);
        //CreateFloor();
        //CreateWalls();
        SpawnInterior();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /* disabled för vernissage, vi skapar rummen själva
    void CreateFloor()
    {
        GameObject newObject = Instantiate(floor, currentLocation + new Vector3(roomSizeX / 2, -0.5f, roomSizeZ / 2), Quaternion.identity);
        newObject.transform.localScale = new Vector3(roomSizeX, 1, roomSizeZ);
    }
    
    void CreateWalls()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                for (int wallCount = 1; wallCount < wallLenghtX; wallCount++)
                {
                    if (wallCount == wallLenghtX / 2)
                    {

                    }
                    else
                    {
                        GameObject newObject = Instantiate(wall, currentLocation + new Vector3(wallCount, wallHeight / 2, 0.49f), Quaternion.identity);
                        newObject.transform.localScale = new Vector3(1, wallHeight, 0.45f);
                        newObject.name = "wallX1 " + wallCount;

                    }
                }
            }
            else if (i == 1)
            {
                for (int wallCount = 1; wallCount < wallLenghtZ; wallCount++)
                {
                    GameObject newObject = Instantiate(wall, currentLocation + new Vector3(0.49f, wallHeight / 2, wallCount), Quaternion.identity);
                    newObject.transform.localScale = new Vector3(1, wallHeight, 0.45f);
                    newObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    newObject.name = "wallX2 " + wallCount;
                }
            }
            else if (i == 2)
            {
                for (int wallCount = 1; wallCount < wallLenghtX; wallCount++)
                {
                    GameObject newObject = Instantiate(wall, currentLocation + new Vector3(wallCount, wallHeight / 2, wallLenghtZ -0.49f), Quaternion.identity);
                    newObject.transform.localScale = new Vector3(1, wallHeight, 0.45f);
                    newObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    newObject.name = "wallX3 " + wallCount;
                }
            }
            else if (i == 3)
            {
                for (int wallCount = 1; wallCount < wallLenghtZ; wallCount++)
                {
                    GameObject newObject = Instantiate(wall, currentLocation + new Vector3(wallLenghtX -0.49f, wallHeight / 2, wallCount), Quaternion.identity);
                    newObject.transform.localScale = new Vector3(1, wallHeight, 0.45f);
                    newObject.transform.localRotation = Quaternion.Euler(0, 270, 0);
                    newObject.name = "wallX4 " + wallCount;
                }
            }

        }
    }
    */
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

                    if (x == 1 && z == 1 || x == 2 && z == 1|| x == roomSizeX - 1 && z == roomSizeZ - 1 || x == roomSizeX - 2 && z == roomSizeZ - 1 || x == 1 && z == roomSizeZ - 1 || x == 2 && z == roomSizeZ - 1 || z == 1 && x == roomSizeX - 1 || z == 2 && x == roomSizeX - 1)
                    {
                        //wallFurnitureSpawned = true;
                        canSpawn[x, z] = 9;
                    }

                    if (x == 1 && canSpawn[x, z] == 0 || x == 1 && z == 1 && canSpawn[x, z] == 0)
                    {
                        ImprovedInstantiate(wallFurniture[randomWallFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, 0, 0));
                        //wallFurnitureSpawned = true;
                        canSpawn[x, z] = 9;
                        canSpawn[x, z + 1] = 9;
                        canSpawn[x, z - 1] = 9;

                        if (z == 2)
                        {
                            canSpawn[x, z - 2] = 9;
                            canSpawn[x, z + 2] = 9;
                            canSpawn[x, z + 3] = 9;
                        }
                        else if (z == roomSizeZ -3)
                        {
                            canSpawn[x, z + 2] = 9;
                            canSpawn[x, z - 2] = 9;
                            canSpawn[x, z - 3] = 9;
                        }
                        else if (z > 3 && z < roomSizeZ - 4)
                        {
                            canSpawn[x, z - 2] = 9;
                            canSpawn[x, z - 3] = 9;
                            canSpawn[x, z + 2] = 9;
                            canSpawn[x, z + 3] = 9;
                        }
                        wFurnitureX = x;
                        wFurnitureZ = z;
                    }

                    else if (z == 1 && canSpawn[x, z] == 0)
                    {
                        ImprovedInstantiate(wallFurniture[randomWallFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, 270, 0));
                        //wallFurnitureSpawned = true;
                        canSpawn[x, z] = 9;
                        canSpawn[x + 1, z] = 9;
                        canSpawn[x - 1, z] = 9;

                        if (x == 2)
                        {
                            canSpawn[x - 2, z] = 9;
                            canSpawn[x + 2, z] = 9;
                            canSpawn[x + 3, z] = 9;
                        }
                        else if (x == roomSizeX - 3)
                        {
                            canSpawn[x + 2, z] = 9;
                            canSpawn[x - 2, z] = 9;
                            canSpawn[x - 3, z] = 9;
                        }
                        else if (x > 3 && x < roomSizeX - 4)
                        {
                            canSpawn[x - 2, z] = 9;
                            canSpawn[x - 3, z] = 9;
                            canSpawn[x + 2, z] = 9;
                            canSpawn[x + 3, z] = 9;
                        }

                        wFurnitureX = x;
                        wFurnitureZ = z;
                    }
                    else if (x == roomSizeX - 1 && canSpawn[x, z] == 0)
                    {
                        ImprovedInstantiate(wallFurniture[randomWallFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, 180, 0));
                        //wallFurnitureSpawned = true;
                        canSpawn[x, z] = 9;
                        canSpawn[x, z + 1] = 9;
                        canSpawn[x, z - 1] = 9;

                        if (z == 2)
                        {
                            canSpawn[x, z - 2] = 9;
                            canSpawn[x, z + 2] = 9;
                            canSpawn[x, z + 3] = 9;
                        }
                        else if (z == roomSizeZ - 3)
                        {
                            canSpawn[x, z + 2] = 9;
                            canSpawn[x, z - 2] = 9;
                            canSpawn[x, z - 3] = 9;
                        }
                        else if (z > 3 && z < roomSizeZ - 4)
                        {
                            canSpawn[x, z - 2] = 9;
                            canSpawn[x, z - 3] = 9;
                            canSpawn[x, z + 2] = 9;
                            canSpawn[x, z + 3] = 9;
                        }
                        wFurnitureX = x;
                        wFurnitureZ = z;
                    }
                    else if (z == roomSizeZ - 1 && canSpawn[x, z] == 0 || z == roomSizeZ - 1 && x == roomSizeX - 1 && canSpawn[x, z] == 0)
                    {
                        ImprovedInstantiate(wallFurniture[randomWallFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, 90, 0));
                        //wallFurnitureSpawned = true;
                        canSpawn[x, z] = 9;
                        canSpawn[x + 1, z] = 9;
                        canSpawn[x - 1, z] = 9;

                        if (x == 2)
                        {
                            canSpawn[x - 2, z] = 9;
                            canSpawn[x + 2, z] = 9;
                            canSpawn[x + 3, z] = 9;
                        }
                        else if (x == roomSizeX - 3)
                        {
                            canSpawn[x + 2, z] = 9;
                            canSpawn[x - 2, z] = 9;
                            canSpawn[x - 3, z] = 9;
                        }
                        else if (x > 3 && x < roomSizeX - 4)
                        {
                            canSpawn[x - 2, z] = 9;
                            canSpawn[x - 3, z] = 9;
                            canSpawn[x + 2, z] = 9;
                            canSpawn[x + 3, z] = 9;
                        }
                        wFurnitureX = x;
                        wFurnitureZ = z;
                    }
                    else if (x > 1 && x < roomSizeX - 1 && z > 1 && z < roomSizeZ - 1 && canSpawn[x, z] != 9)
                    {
                        var randomRotation = Random.Range(0, 359);
                        ImprovedInstantiate(furniture[randomFurniture], currentLocation + new Vector3(x, 0, z), new Vector3(0, randomRotation, 0));

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
                    int randomLampSpawn = Random.Range(0, 5);
                    if (x > 1 && x < roomSizeX - 1 && z > 1 && z < roomSizeZ - 1 && randomLampSpawn == 1)
                    {
                        GameObject newObject = Instantiate(lamp, currentLocation + new Vector3(x, wallHeight, z), Quaternion.Euler(180, 0, 0));
                        newObject.transform.localScale = new Vector3(70, 15, 70);
                        lampCount++;
                    }
                }
            }
        }
        if (lampCount == 0)
        {
            GameObject newObject = Instantiate(lamp, currentLocation + new Vector3(roomSizeX / 2, wallHeight, roomSizeZ / 2), Quaternion.Euler(180, 0, 0));
            newObject.transform.localScale = new Vector3(70, 15, 70);
        }
    }
}

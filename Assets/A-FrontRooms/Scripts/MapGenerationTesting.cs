using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationTesting : AddedCommands
{
    int[,] groundSpawn;
    [SerializeField]
    int groundSizeX;
    [SerializeField]
    int groundSizeZ;
    public int wallCount;
    public int groundCount;
    public int removedGround;
    int doorsSpawned = 0;
    public int maxDoorSpawned = 1;

    Vector3 currentLocation;
    [SerializeField]
    GameObject wall;
    [SerializeField]
    GameObject floor;
    [SerializeField]
    GameObject floor2;
    [SerializeField]
    GameObject generator;


    public void Start()
    {
        spawnGround();
    }
    void spawnGround()
    {
        // *2 to get guaranteed even numbers
        groundSizeX = Random.Range(5, 15) * 2;
        groundSizeZ = Random.Range(5, 15) * 2;

        groundSpawn = new int[groundSizeX, groundSizeZ];
        for (int x = 0; x < groundSizeX; x++)
        {
            for (int z = 0; z < groundSizeZ; z++)
            {
                groundSpawn[x, z] = 1;
            }
        }
    for (int x = 0; x < groundSizeX; x++)
        {
            for (int z = 0; z < groundSizeZ; z++)
            {
                if (x == 0 || x == groundSizeX - 1 || z == 0 || z == groundSizeZ - 1)
                {
                    if ( ( x == 0 && z == 0 ) || (x == 0 && z == groundSizeZ) || (x == groundSizeX && z == 0) || (x == groundSizeX && z == groundSizeZ) )
                    {
                        //It's a corner
                        groundSpawn[x, z] = 1;
                        wallCount += 1;
                    }
                    else
                    {
                        int random = Random.Range(1, 20);
                        if (doorsSpawned < maxDoorSpawned && random == 5)
                        {
                            print(x + " : " + z);
                            for (int x2 = x - 2; x2 < x + 3; x2++)
                            {
                                for (int z2 = z - 2; z2 < z + 3; z2++)
                                {
                                    if ((x2 >= 0 && z2 >= 0 && x2 < groundSizeX - 1 && z2 < groundSizeZ -1))
                                    {
                                        if (groundSpawn[x2, z2] == 1)
                                        {
                                            groundSpawn[x2, z2] = -5;
                                        }
                                    }
                                }
                            }
                            doorsSpawned++;
                            groundSpawn[x, z] = -4;
                        }
                        else
                        {
                            groundSpawn[x, z] = 1;
                            wallCount += 1;
                        }
                    }
                }
                else
                {
                    groundSpawn[x, z] = 0;
                    groundCount += 1;
                }
            }
        }

        currentLocation = gameObject.transform.position - new Vector3(groundSizeX / 2, 0, groundSizeZ / 2);

        for (int x = 0; x < groundSizeX; x++)
        {
            for (int z = 0; z < groundSizeZ; z++)
            {
                if (groundSpawn[x, z] == 1)
                {
                    ImprovedInstantiate(wall, currentLocation + new Vector3(x, 2, z), new Vector3(0, 0, 0));
                }
                else if (groundSpawn[x, z] == -4)
                {
                    GameObject Generator = Instantiate(generator, currentLocation + new Vector3(x, 0 ,z), Quaternion.Euler(0,0,0));
                    Generator.transform.parent = gameObject.transform.parent;
                }
                if (groundSpawn[x, z] == 0)
                {
                    ImprovedInstantiate(floor, currentLocation + new Vector3(x, 0, z), new Vector3(0, 0, 0));
                    
                    for (int x2 = x - 1; x2 < x + 2; x2++)
                    {
                        for (int z2 = z - 1; z2 < z + 2; z2++)
                        {
                            if (groundSpawn[x2, z2] == 0)
                            {
                                groundSpawn[x2, z2] = -2;
                            }

                        }
                    }
                }
                else if (groundSpawn[x, z] == -2)
                {
                    removedGround++;
                    ImprovedInstantiate(floor2, currentLocation + new Vector3(x, 0, z), new Vector3(0, 0, 0));
                }
            }
        }
    }
}

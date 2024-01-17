using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingScript : MonoBehaviour
{
    private bool Hiding;
    Pathfinding.MonsterTargeting monstertargeting;
    [SerializeField]
    GameObject Player;
    public bool Untargetable;

    private void Start()
    {
        monstertargeting = GetComponent<Pathfinding.MonsterTargeting>();
        Hiding = false;
    }

    public void Update()
    {
        if(Hiding == true)
        {
          //  Player != detectable;
        }
        else
        {
            //Player = detectable;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("MainCamera"))     
        {
            Hiding = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("MainCamera"))
        {
            Hiding = false;
        }
    }

}

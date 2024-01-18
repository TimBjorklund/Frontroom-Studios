using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingScript : MonoBehaviour
{
    public bool Hiding;
    [SerializeField]
    Pathfinding.MonsterTargeting monstertargeting;
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
            Untargetable = true;
          //  Player != detectable;
        }
        else
        {
            Untargetable = false;
            //Player = detectable;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
       if (collision.CompareTag("MainCamera") || collision.gameObject.name == "Test")     
        {
            Hiding = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("MainCamera") || collision.gameObject.name == "Test")
        {
            Hiding = false;
        }
    }

}

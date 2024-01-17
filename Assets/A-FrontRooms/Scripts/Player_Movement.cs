using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


public class Player_Movement : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider MP;
    public float sprintTime;
    public bool isRunning = false;
    public bool isMoving;
    public AudioSource footsteps;
    public AudioClip footsteps2;
    public AudioSource andf�dd;
    // Update is called once per frame

    private void Start()
    {
        MP = gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.L))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving == true)
        {
            footsteps.enabled = true;

        }
        else
        {
            footsteps.enabled = false;
        }


        if (isRunning == true)
        {
            sprintTime -= Time.deltaTime;
        }
        else
        {
            sprintTime += Time.deltaTime;
            if (sprintTime > 5)
            {
                sprintTime = 5;
            }
        }
        if (sprintTime <= 0)
        {
            Movement_StopSprint();
            andf�dd.Play();
        }


    }


    public void Shoot(InputAction.CallbackContext context)
    {
        Lower = context.ReadValue<bool>();

        print("Pang");
    }
    public void Movement_Sprint()
    {
        isRunning = true;
        
        MP.moveSpeed = MP.moveSpeed * 2;
    }
    public void Movement_StopSprint()
    {
        isRunning = false;
        MP.moveSpeed = MP.moveSpeed / 2;
    }
    public void Moveing()
    {   
        isMoving = true;
        
    }
}

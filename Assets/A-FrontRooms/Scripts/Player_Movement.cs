using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


public class Player_Movement : UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider
{
    bool Lower;
    float sprintTime;
    bool isRunning = false;
    public bool isMoving;
    public AudioSource footsteps;
    public AudioClip footsteps2;
    // Update is called once per frame


    protected override void Update()
    {
        base.Update();
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

        moveSpeed = moveSpeed * 2;
    }
    public void Movement_StopSprint()
    {
        isRunning = false;
        moveSpeed = moveSpeed / 2;
    }
    public void Moveing()
    {   
        isMoving = true;
        
    }
}

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
    public bool isMoving;
    public AudioSource footsteps;
    public AudioClip footsteps2;
    // Update is called once per frame


    protected override void Update()
    {
        if(Input.GetKey(KeyCode.L))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        base.Update();
        if(isMoving == true)
        {
            footsteps.enabled = true;

        }
        else
        {
            footsteps.enabled = false;
        }
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        Lower = context.ReadValue<bool>();

        print("Pang");
    }
    public void Movement_Sprint()
    {
        moveSpeed = moveSpeed * 2;
    }
    public void Movement_StopSprint()
    {
        moveSpeed = moveSpeed / 2;
    }
    public void Moveing()
    {   
        isMoving = true;
        
    }
}

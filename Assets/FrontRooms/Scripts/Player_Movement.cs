using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider
{

    bool Lower;
    // Update is called once per frame


    protected override void Update()
    {
        base.Update();
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

}

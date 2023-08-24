using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerJumpingBaseState
{
    public PlayerGroundedState(PlayerJumpingStateMachine playerJumpingStateMachine) : base(playerJumpingStateMachine)
    {
    }

    public override void UpdateFrame()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        Debug.Log(IsGrounded());
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Vector2 newVelocity = stateMachine.playerRigidBody2D.velocity;
            newVelocity.y = PlayerJumpingStateMachine.JUMP_VELOCITY;
            stateMachine.playerRigidBody2D.velocity = newVelocity;
        }
    }

    public override void UpdatePhysics()
    {

        if (stateMachine.playerRigidBody2D.velocity.y > 0 && !IsGrounded())
        {
            stateMachine.ChangeState(stateMachine.playerJumpingState);
        }
        else if (stateMachine.playerRigidBody2D.velocity.y < 0 && !IsGrounded())
        {
            stateMachine.ChangeState(stateMachine.playerFallingState);
        }

    }
}

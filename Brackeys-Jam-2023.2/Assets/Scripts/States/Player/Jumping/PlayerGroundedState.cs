using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerJumpingBaseState
{
    public PlayerGroundedState(PlayerJumpingStateMachine playerJumpingStateMachine) : base(playerJumpingStateMachine)
    {
    }

    public override void UpdateFrame() {
        HandleJump();
    }

    private void HandleJump() {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {

        }
    }

    public override void UpdatePhysics() {
        if (!IsGrounded()) {
           if (stateMachine.playerRigidBody2D.velocity.y > 0) {
                stateMachine.ChangeState(stateMachine.playerJumpingState);
           } else {
                stateMachine.ChangeState(stateMachine.playerFallingState);
           }
        }
    }
}

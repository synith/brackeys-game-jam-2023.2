using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerJumpingBaseState
{
    public PlayerJumpingState(PlayerJumpingStateMachine playerJumpingStateMachine) : base(playerJumpingStateMachine)
    {
    }

    public override void EnterState() {
        stateMachine.animator.SetBool("isJumping", true);
    }

    public override void UpdatePhysics() {
        if (IsGrounded()) {
            stateMachine.ChangeState(stateMachine.playerGroundedState);
        }
        else if (stateMachine.playerRigidBody2D.velocity.y < 0) {
            stateMachine.ChangeState(stateMachine.playerFallingState);
        }
    }
}

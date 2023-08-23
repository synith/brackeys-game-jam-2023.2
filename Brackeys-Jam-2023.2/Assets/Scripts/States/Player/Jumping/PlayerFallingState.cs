using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerJumpingBaseState
{
    public PlayerFallingState(PlayerJumpingStateMachine playerJumpingStateMachine) : base(playerJumpingStateMachine)
    {
    }

    public override void UpdatePhysics() {
        if (IsGrounded()) {
            stateMachine.ChangeState(stateMachine.playerGroundedState);
        }
    }
}

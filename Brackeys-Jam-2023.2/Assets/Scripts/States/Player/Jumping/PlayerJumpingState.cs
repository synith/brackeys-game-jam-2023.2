using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerJumpingBaseState
{
    public PlayerJumpingState(PlayerJumpingStateMachine playerJumpingStateMachine) : base(playerJumpingStateMachine)
    {
    }

    public override void UpdatePhysics() {
        if (IsGrounded()) {
            stateMachine.ChangeState(stateMachine.playerGroundedState);
        }
    }
}

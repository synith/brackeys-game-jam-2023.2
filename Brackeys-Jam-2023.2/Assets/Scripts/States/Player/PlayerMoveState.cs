using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void UpdatePhysics()
    {
        Vector2 velocity = playerStateMachine.playerRigidBody2D.velocity;
        velocity.x = Mathf.Lerp(playerStateMachine.playerRigidBody2D.velocity.x, playerStateMachine.targetVelocity, ACCELERATION_SPEED);
        playerStateMachine.playerRigidBody2D.velocity = velocity;
    }
}

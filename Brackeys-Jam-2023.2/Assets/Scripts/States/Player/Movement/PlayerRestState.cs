using UnityEngine;

public class PlayerRestState : PlayerMovementBaseState
{
    public PlayerRestState(PlayerMovementStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void UpdatePhysics()
    {
        Vector2 velocity = playerStateMachine.playerRigidBody2D.velocity;
        velocity.x = Mathf.Lerp(playerStateMachine.playerRigidBody2D.velocity.x, 0, DECELERATION_SPEED);
        playerStateMachine.playerRigidBody2D.velocity = velocity;
    }
}

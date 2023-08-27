using UnityEngine;

public class PlayerRestState : PlayerMovementBaseState
{
    public PlayerRestState(PlayerMovementStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void EnterState() {
        stateMachine.animator.SetBool("isWalking", false);
    }

    public override void UpdatePhysics()
    {
        Vector2 velocity = stateMachine.playerRigidBody2D.velocity;
        velocity.x = Mathf.Lerp(stateMachine.playerRigidBody2D.velocity.x, 0, DECELERATION_SPEED);
        stateMachine.playerRigidBody2D.velocity = velocity;
    }
}

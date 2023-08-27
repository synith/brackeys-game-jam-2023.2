using UnityEngine;

public class PlayerMoveState : PlayerMovementBaseState
{
    public PlayerMoveState(PlayerMovementStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void EnterState() {
        stateMachine.animator.SetBool("isWalking", true);
    }

    public override void UpdatePhysics()
    {
        Vector2 velocity = stateMachine.playerRigidBody2D.velocity;
        velocity.x = Mathf.Lerp(stateMachine.playerRigidBody2D.velocity.x, stateMachine.targetVelocity, ACCELERATION_SPEED);
        stateMachine.playerRigidBody2D.velocity = velocity;
    }
}

using UnityEngine;

public abstract class PlayerJumpingBaseState : IState
{
    private protected PlayerJumpingStateMachine stateMachine;

    public PlayerJumpingBaseState(PlayerJumpingStateMachine playerJumpingStateMachine)
    {
        stateMachine = playerJumpingStateMachine;
    }

    public virtual void EnterState()
    {

    }

    public virtual void ExitState()
    {

    }

    public virtual void UpdateFrame()
    {

    }

    public virtual void UpdatePhysics()
    {

    }

    private protected bool IsGrounded() {
        float detectionHeight = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(stateMachine.boxCollider.bounds.center, stateMachine.boxCollider.bounds.size, 0f, Vector2.down, detectionHeight, LayerMask.GetMask("Solid"));
        return raycastHit.collider != null;
    }
}

using UnityEngine;

public abstract class PlayerStatusBaseState : IState
{
    private protected PlayerStatusStateMachine stateMachine;

    public PlayerStatusBaseState(PlayerStatusStateMachine playerStatusStateMachine)
    {
        stateMachine = playerStatusStateMachine;
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

    public virtual void HandleCollision(Collision2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collectable")) {
            stateMachine.oxygenCount = stateMachine.maxOxygenCapacity;
            Object.Destroy(other.gameObject);
        }
    }
}

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
        return false;
    }
}

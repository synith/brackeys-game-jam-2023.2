public abstract class PlayerMovementBaseState : IState
{
    private protected PlayerMovementStateMachine stateMachine;

    // Parameters
    private protected const float ACCELERATION_SPEED = 0.1f;
    private protected const float DECELERATION_SPEED = 0.1f;

    public PlayerMovementBaseState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        stateMachine = playerMovementStateMachine;
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

}

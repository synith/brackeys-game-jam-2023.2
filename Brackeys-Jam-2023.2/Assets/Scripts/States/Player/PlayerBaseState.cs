public abstract class PlayerBaseState : IState
{
    private protected PlayerStateMachine playerStateMachine;

    private protected const float ACCELERATION_SPEED = 0.1f;
    private protected const float DECELERATION_SPEED = 0.1f;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
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

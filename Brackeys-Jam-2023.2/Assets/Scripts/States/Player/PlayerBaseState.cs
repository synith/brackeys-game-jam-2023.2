public abstract class PlayerBaseState : IState
{
    public PlayerStateMachine playerStateMachine;

    public PlayerBaseState(PlayerStateMachine playerStateMachine) {
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

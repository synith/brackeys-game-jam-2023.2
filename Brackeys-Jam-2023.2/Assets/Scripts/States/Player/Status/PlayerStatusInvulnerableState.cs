using System.Threading.Tasks;

public class PlayerStatusInvulnerableState : PlayerStatusBaseState
{
    // Parameter
    private const int INVULNERABILITY_DURATION = 2000; // ms

    public PlayerStatusInvulnerableState(PlayerStatusStateMachine playerStatusStateMachine) : base(playerStatusStateMachine)
    {
    }

    public override void EnterState() {
        Task.Delay(INVULNERABILITY_DURATION).ContinueWith(t => stateMachine.ChangeState(stateMachine.playerStatusNormalState));
    }
}
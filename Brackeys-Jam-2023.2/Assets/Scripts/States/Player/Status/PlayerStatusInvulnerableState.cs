using System.Threading.Tasks;
using UnityEngine;

public class PlayerStatusInvulnerableState : PlayerStatusBaseState
{
    // Parameter
    private const int INVULNERABILITY_DURATION = 2000; // ms

    public PlayerStatusInvulnerableState(PlayerStatusStateMachine playerStatusStateMachine) : base(playerStatusStateMachine)
    {
    }

    public override void EnterState() {
        //stateMachine.spriteRenderer.color = Color.red;
        Task.Delay(INVULNERABILITY_DURATION).ContinueWith(t => stateMachine.ChangeState(stateMachine.playerStatusNormalState));
    }

    public override void ExitState() {
        //stateMachine.spriteRenderer.color = Color.white;
    }

}
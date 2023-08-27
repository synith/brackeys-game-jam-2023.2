using UnityEngine;

public class PlayerStatusInvulnerableState : PlayerStatusBaseState
{
    // Parameter
    private const int INVULNERABILITY_DURATION = 2;

    public PlayerStatusInvulnerableState(PlayerStatusStateMachine playerStatusStateMachine) : base(playerStatusStateMachine)
    {
    }

    public override void EnterState() {
        stateMachine.Invoke("ExitInvulnerability", 1);
    }

    public override void ExitState() {
        stateMachine.spriteRenderer.color = Color.white;
    }

}
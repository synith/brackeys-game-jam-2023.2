using UnityEngine;

public class PlayerStatusNormalState : PlayerStatusBaseState
{
    public PlayerStatusNormalState(PlayerStatusStateMachine playerStatusStateMachine) : base(playerStatusStateMachine)
    {
    }

    public override void EnterState() {
    }

    public override void HandleCollision(Collision2D other) {
        base.HandleCollision(other);
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            stateMachine.TakeDamage(1f);
            stateMachine.ChangeState(stateMachine.playerStatusInvulnerableState);
        }
    }
}
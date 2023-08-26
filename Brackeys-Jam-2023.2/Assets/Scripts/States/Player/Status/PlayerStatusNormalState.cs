using UnityEngine;

public class PlayerStatusNormalState : PlayerStatusBaseState
{
    public PlayerStatusNormalState(PlayerStatusStateMachine playerStatusStateMachine) : base(playerStatusStateMachine)
    {
    }

    public override void EnterState() {
        Debug.Log("not invulnerable anymore!");
    }

    public override void HandleCollision(Collision2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            Debug.Log("ouch");
            stateMachine.TakeDamage(1);
            stateMachine.ChangeState(stateMachine.playerStatusInvulnerableState);
        }
    }
}
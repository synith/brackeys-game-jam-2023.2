using UnityEngine;

public class PlayerStatusNormalState : PlayerStatusBaseState
{
    public PlayerStatusNormalState(PlayerStatusStateMachine playerStatusStateMachine) : base(playerStatusStateMachine)
    {
    }

    public override void HandleCollision(Collision2D other) {
        if (true) {

        }
    }
}
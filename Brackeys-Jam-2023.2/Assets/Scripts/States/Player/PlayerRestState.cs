using UnityEngine;

public class PlayerRestState : PlayerBaseState
{
    public PlayerRestState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void UpdatePhysics() {
        Debug.Log("hi");
    }
}

using UnityEngine;

public abstract class PlayerStatusBaseState : IState
{
    private protected PlayerStatusStateMachine stateMachine;

    public PlayerStatusBaseState(PlayerStatusStateMachine playerStatusStateMachine)
    {
        stateMachine = playerStatusStateMachine;
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

    public virtual void HandleCollision(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collectable"))
        {
            Collectable collectable = other.gameObject.GetComponent<Collectable>();
            if (collectable.collectableType == CollectableType.OxygenTank)
            {
                stateMachine.oxygenCount += 15;
                if (stateMachine.oxygenCount > stateMachine.maxOxygenCapacity)
                {
                    stateMachine.oxygenCount = stateMachine.maxOxygenCapacity;
                }
            }
            else if (collectable.collectableType == CollectableType.Key)
            {
                GameStateMachine.keyCount++;
            }
            else if (collectable.collectableType == CollectableType.Scrap)
            {
                GameStateMachine.scrapCount++;
            }

            Object.Destroy(other.gameObject);
        }
    }
}

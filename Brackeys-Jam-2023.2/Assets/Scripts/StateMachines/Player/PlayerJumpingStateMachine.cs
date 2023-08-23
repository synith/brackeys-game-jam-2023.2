using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingStateMachine : MonoBehaviour
{
    // Fields
    internal Rigidbody2D playerRigidBody2D;

    // States
    private PlayerJumpingBaseState _currentState;
    internal PlayerGroundedState playerGroundedState;
    internal PlayerJumpingState playerJumpingState;
    internal PlayerFallingState playerFallingState; 

    void Awake()
    {
        InitializeStates();
    }

    private void InitializeStates()
    {
        playerGroundedState = new PlayerGroundedState(this);
        playerJumpingState = new PlayerJumpingState(this);
        playerFallingState = new PlayerFallingState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentState = playerGroundedState;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateFrame();
    }

     void FixedUpdate() {
        _currentState.UpdatePhysics();
    }

    internal void ChangeState(PlayerJumpingBaseState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }
}

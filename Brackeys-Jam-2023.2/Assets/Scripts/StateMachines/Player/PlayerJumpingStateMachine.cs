using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingStateMachine : MonoBehaviour
{
    // Components
    internal Rigidbody2D playerRigidBody2D;
    internal BoxCollider2D boxCollider;
    internal Animator animator;

    // States
    private PlayerJumpingBaseState _currentState;
    internal PlayerGroundedState playerGroundedState;
    internal PlayerJumpingState playerJumpingState;
    internal PlayerFallingState playerFallingState; 

    // Parameters
    internal const float JUMP_VELOCITY = 9f;

    private void Awake()
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
    private void Start()
    {
        _currentState = playerGroundedState;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        playerRigidBody2D.freezeRotation = true;
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _currentState.UpdateFrame();
    }

    private void FixedUpdate() {
        _currentState.UpdatePhysics();
    }

    internal void ChangeState(PlayerJumpingBaseState newState)
    {
        if (newState != null)
        {
            _currentState.ExitState();
        }
        _currentState = newState;
        _currentState.EnterState();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
    // Fields
    internal Rigidbody2D playerRigidBody2D;
    internal float targetVelocity;

    // States
    private PlayerMovementBaseState _currentState;
    internal PlayerRestState playerRestState;
    internal PlayerMoveState playerMoveState;

    // Parameters
    private const float _MOVEMENT_SPEED = 5f;

    void Awake()
    {
        InitializeStates();
    }

    private void InitializeStates()
    {
        playerRestState = new PlayerRestState(this);
        playerMoveState = new PlayerMoveState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentState = playerRestState;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateFrame();
    }

    void FixedUpdate()
    {
        HandleMovement();
        _currentState.UpdatePhysics();
    }

    private void HandleMovement()
    {
        if (_currentState != playerRestState
            && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A)
        && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
        {
            targetVelocity = 0;
            ChangeState(playerRestState);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                targetVelocity = -_MOVEMENT_SPEED;
                ChangeState(playerMoveState);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                targetVelocity = _MOVEMENT_SPEED;
                ChangeState(playerMoveState);
            }
        }
    }

    private void ChangeState(PlayerMovementBaseState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }
}

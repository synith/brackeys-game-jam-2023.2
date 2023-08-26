using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
    // Components
    internal Rigidbody2D playerRigidBody2D;
    private SpriteRenderer _spriteRenderer;

    // Fields
    internal float targetVelocity;

    // States
    private PlayerMovementBaseState _currentState;
    internal PlayerRestState playerRestState;
    internal PlayerMoveState playerMoveState;

    // Parameters
    private const float _MOVEMENT_SPEED = 5f;

    private void Awake()
    {
        InitializeStates();
    }

    private void InitializeStates()
    {
        playerRestState = new PlayerRestState(this);
        playerMoveState = new PlayerMoveState(this);
    }

    // Start is called before the first frame update
    private void Start()
    {
        _currentState = playerRestState;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        _currentState.UpdateFrame();
    }

    private void FixedUpdate()
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
                _spriteRenderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                targetVelocity = _MOVEMENT_SPEED;
                ChangeState(playerMoveState);
                _spriteRenderer.flipX = false;
            }
        }
    }

    private void ChangeState(PlayerMovementBaseState newState)
    {
        if (newState != null)
        {
            _currentState.ExitState();
        }
        _currentState = newState;
        _currentState.EnterState();
    }
}

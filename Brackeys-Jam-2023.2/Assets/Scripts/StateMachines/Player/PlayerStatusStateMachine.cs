using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusStateMachine : MonoBehaviour
{
    // States
    private PlayerStatusBaseState _currentState;
    internal PlayerStatusNormalState playerStatusNormalState;
    internal PlayerStatusInvulnerableState playerStatusInvulnerableState;

    void Awake()
    {
        InitializeStates();
    }

    private void InitializeStates()
    {
        playerStatusNormalState = new PlayerStatusNormalState(this);
        playerStatusInvulnerableState = new PlayerStatusInvulnerableState(this);
    }   

    // Start is called before the first frame update
    void Start()
    {
        _currentState = playerStatusInvulnerableState;
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateFrame();
    }

    void FixedUpdate() 
    {
        _currentState.UpdatePhysics();
    }

    private void ChangeState(PlayerStatusBaseState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }
}

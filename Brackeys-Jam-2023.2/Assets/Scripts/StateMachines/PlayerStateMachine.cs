using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    // States
    private PlayerBaseState _currentState;
    internal PlayerRestState playerRestState;
    internal PlayerMoveState playerMoveState;
    internal PlayerAirborneState playerAirborneState;

    void Awake() {
        InitializeStates();
    }

    private void InitializeStates() {
        playerRestState = new PlayerRestState(this);
        playerMoveState = new PlayerMoveState(this);
        playerAirborneState = new PlayerAirborneState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentState = playerRestState;
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
}

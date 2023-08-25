using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusStateMachine : MonoBehaviour
{
    // Fields
    private int _oxygenCount;

    // States
    private PlayerStatusBaseState _currentState;
    internal PlayerStatusNormalState playerStatusNormalState;
    internal PlayerStatusInvulnerableState playerStatusInvulnerableState;

    // Parameters
    internal int maxOxygenCapacity;

    private void Awake()
    {
        InitializeStates();
        maxOxygenCapacity = 100;
        _oxygenCount = maxOxygenCapacity;
    }

    private void InitializeStates()
    {
        playerStatusNormalState = new PlayerStatusNormalState(this);
        playerStatusInvulnerableState = new PlayerStatusInvulnerableState(this);
    }   

    // Start is called before the first frame update
    private void Start()
    {
        _currentState = playerStatusInvulnerableState;
    }

    // Update is called once per frame
    private void Update()
    {
        _currentState.UpdateFrame();
    }

    private void FixedUpdate() 
    {
        if (haveO2()) {
            
        }
        else {
            _currentState.UpdatePhysics();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        _currentState.HandleCollision(other);
    }

    private void ChangeState(PlayerStatusBaseState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    public void TakeDamage(int damage) {
        _oxygenCount -= damage;
    }

    private bool haveO2() {
        return _oxygenCount > 0;
    }
}

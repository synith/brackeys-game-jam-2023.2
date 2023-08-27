using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatusStateMachine : MonoBehaviour
{
    // Components
    public GameObject _oxygenMeter;
    internal SpriteRenderer spriteRenderer;
    private TextMeshProUGUI _oxygenDisplayTMP;

    // Fields
    internal float oxygenCount;

    // States
    private PlayerStatusBaseState _currentState;
    internal PlayerStatusNormalState playerStatusNormalState;
    internal PlayerStatusInvulnerableState playerStatusInvulnerableState;

    // Parameters
    internal int maxOxygenCapacity;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        InitializeStates();
    }

    private void InitializeStates()
    {
        playerStatusNormalState = new PlayerStatusNormalState(this);
        playerStatusInvulnerableState = new PlayerStatusInvulnerableState(this);
    }

    // Start is called before the first frame update
    private void Start()
    {
        maxOxygenCapacity = 100;
        oxygenCount = maxOxygenCapacity;
        _currentState = playerStatusInvulnerableState;
        _currentState.EnterState();
        _oxygenDisplayTMP = _oxygenMeter.GetComponent<TextMeshProUGUI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        _currentState.UpdateFrame();
        _oxygenDisplayTMP.text = Mathf.CeilToInt(oxygenCount).ToString();
    }

    private void FixedUpdate()
    {
        if (HaveO2())
        {
            oxygenCount -= 0.5f * Time.deltaTime;
        }
        else
        {
            _currentState.UpdatePhysics();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _currentState.HandleCollision(other);
    }

    public void TakeDamage(float damage)
    {
        spriteRenderer.color = Color.red;
        oxygenCount -= damage;
    }

    private bool HaveO2()
    {
        return oxygenCount > 0;
    }

    internal void ExitInvulnerability() {
        ChangeState(playerStatusNormalState);
    }

    internal void ChangeState(PlayerStatusBaseState newState)
    {
        if (newState != null)
        {
            _currentState.ExitState();
        }
        _currentState = newState;
        _currentState.EnterState();
    }
}

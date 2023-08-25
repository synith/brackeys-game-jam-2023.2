using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthStateMachine : MonoBehaviour
{
    private int _health;

    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() {
        string healthDisplay = "Health: " + _health.ToString();
        GUILayout.Label(healthDisplay);
    }
}

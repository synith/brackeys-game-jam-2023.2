using System;
using Unity.VisualScripting;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Field
    bool isLocked = true;

    // Events
    public static event Action OnReachingExit;

    // Start is called before the first frame update
    void Start()
    {
        GameStateMachine.OnGettingAllKeys += UnlockDoor;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (isLocked)
            {
                Debug.Log("locked!");
            }
            else
            {
                OnReachingExit?.Invoke();
            }
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
    }
}

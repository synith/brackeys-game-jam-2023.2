using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiver : MonoBehaviour
{
    private CharacterController characterController;
    private Transform characterMesh;

    public float swimSpeed = 5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterMesh = GetComponent<Transform>();
        Debug.Log(characterMesh);
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        characterController.Move(move * Time.deltaTime * swimSpeed);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null && !rb.isKinematic)
        {
            rb.velocity = hit.moveDirection * 2f;
        }
    }
}

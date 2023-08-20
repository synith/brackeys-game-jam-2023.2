using UnityEngine;

public class RigidbodyCharacter : MonoBehaviour
{
    public float Speed = 15f;

    private Rigidbody rb;
    private Vector3 inputs = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");
        if (inputs != Vector3.zero)
            transform.forward = inputs;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputs * Speed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        // I'm just resetting the angles here because the rigidbody was spazzing out
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
}
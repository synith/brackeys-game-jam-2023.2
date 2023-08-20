using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Junk : MonoBehaviour
{
    private Rigidbody rb;

    public float min = 0f;
    public float max = 5f;

    void Start()
    {
        // Generate a random starting velocity
        rb = GetComponent<Rigidbody>();
        Vector3 randomVector = new Vector3(UnityEngine.Random.Range(min, max), UnityEngine.Random.Range(min, max), UnityEngine.Random.Range(min, max));
        rb.velocity = randomVector;
    }
}

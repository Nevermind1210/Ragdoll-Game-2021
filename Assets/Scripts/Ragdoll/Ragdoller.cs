using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoller : MonoBehaviour
{
    private Vector3 startingPosition;
    
    private void Start()
    {
        startingPosition = transform.position;
        DisableRagdoll();
    }

    private void Update()
    {
        if (startingPosition != transform.position)
        {
            EnableRagdoll();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // if ragdoll is hit by pizza, enable it.
        if (collider.GetComponent<Collider>().CompareTag("Pizza"))
        {
            EnableRagdoll();
        }
    }

    void EnableRagdoll()
    {
        // Lets get all the rigidbodies in the ragdoll!
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        // Moveable kinematic
        foreach (var body in bodies)
        {
            body.isKinematic = false;
        }
    }

    void DisableRagdoll()
    {
        // Lets get all the rigidbodies in the ragdoll!
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        // Immovable Kinematic
        foreach (var body in bodies)
        {
            body.isKinematic = true;
        }
    }
}

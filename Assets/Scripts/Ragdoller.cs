using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoller : MonoBehaviour
{
    void OnEnable()
    {
        DisableRagdoll();
    }

    void DisableRagdoll()
    {
        var bodies = GetComponentsInChildren<Rigidbody>();

        foreach (var body in bodies)
        {
            body.isKinematic = true;
        }

        var anim = GetComponent<Animator>();
        anim.enabled = true;
    }

    void EnableRagdoll()
    {
        var bodies = GetComponentsInChildren<Rigidbody>();

        foreach (var body in bodies)
        {
            body.isKinematic = false;
        }

        var anim = GetComponent<Animator>();
        anim.enabled = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Ragdoller ragdoll;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ragdoll"))
        {
            ragdoll._IsDead = true;
        }
    }
}

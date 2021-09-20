using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class RagdollDestroyer : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Ragdoll"))
            {
                Destroy(collision.transform.parent.parent.parent.parent.gameObject);
            }
        }
    }
}
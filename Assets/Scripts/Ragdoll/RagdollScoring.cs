using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class RagdollScoring : MonoBehaviour
    {
        private Joint[] _joints;
        [SerializeField] private float minForceToAddScore = 1f;
        public float currentScore = 0;
        private void OnEnable()
        {
            _joints = GetComponentsInChildren<Joint>();
        }

        private void FixedUpdate()
        {
            currentScore += ScoreRagdoll();
        }

        private float ScoreRagdoll()
        {
            float totalForce = 0;
            foreach (Joint joint in _joints)
            {
                if (joint.currentForce.magnitude > minForceToAddScore)
                {
                      totalForce += joint.currentForce.magnitude;
                }
            }
            return totalForce;
        }
    }
}
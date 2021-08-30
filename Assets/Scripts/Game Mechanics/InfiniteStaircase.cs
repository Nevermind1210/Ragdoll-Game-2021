using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InfiniteStaircase : MonoBehaviour
    {
        public Transform target;

        private void OnTriggerEnter(Collider col)
        {
            Vector3 offset = col.transform.position - transform.position;
            col.transform.position = target.position;
        }
    }
}
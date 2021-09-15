using System;
using UnityEngine;

namespace Game_Mechanics
{
    public class ObjectLerp : MonoBehaviour
    {
        [SerializeField] private Vector3 pointA = new Vector3(0, 0, 0);
        [SerializeField] private Vector3 pointB = new Vector3(1, 1, 1);

        private void Update()
        {
            // Super smooth movement between two points with an object!
            transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
        }
    }
}
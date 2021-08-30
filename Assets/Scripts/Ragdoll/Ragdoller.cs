using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Ragdoller : MonoBehaviour
{
    public Waypoint[] Waypoint;
    [SerializeField] private GameObject _ragdoll;
    [SerializeField] private Animator _animatedModel;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public bool _IsDead;

    private void Awake()
    {
        _ragdoll.gameObject.SetActive(false);
    }

    private void Update()
    {
        Waypoint _waypoint = Waypoint[0];
        _navMeshAgent.SetDestination(_waypoint.transform.position);
    }

    [ContextMenu("ToggleDead")]

    
    
    private void ToggleDead()
    {
        _IsDead = !_IsDead;

        if (_IsDead)
        {
            CopyTransformData(_animatedModel.transform, _ragdoll.transform, _navMeshAgent.velocity);
            _ragdoll.gameObject.SetActive(true);
            _animatedModel.gameObject.SetActive(false);
            _navMeshAgent.enabled = false;
        }
        else
        {
            _ragdoll.gameObject.SetActive(false);
            _animatedModel.gameObject.SetActive(true);
            _navMeshAgent.enabled = true;
        }
    }

    private void CopyTransformData(Transform sourceTransform, Transform destinationTransform, Vector3 velocity)
    {
        if (sourceTransform.childCount != destinationTransform.childCount)
        {
            Debug.LogWarning("Invalid transform copy, they need to match transform hierarchies");
            return;
        }

        for (int i = 0; i < sourceTransform.childCount; i++)
        {
            var source = sourceTransform.GetChild(i);
            var destination = destinationTransform.GetChild(i);
            destination.position = source.position;
            destination.rotation = source.rotation;
            var rb = destination.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = velocity;
            
            CopyTransformData(source, destination, velocity);
        }
    }
}

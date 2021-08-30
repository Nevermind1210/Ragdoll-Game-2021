using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Wanderer : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_navMeshAgent.enabled == false)
            return;

        if (_navMeshAgent.hasPath == false || _navMeshAgent.remainingDistance < 1f)
            ChooseNewPosition();
    }

    private void ChooseNewPosition()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        var destination = transform.position + randomOffset;
        _navMeshAgent.SetDestination(destination);
    }
}

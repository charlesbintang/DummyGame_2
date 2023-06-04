using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    // [SerializeField] private Transform movePositionTransform;
    Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        movePositionTransform = GameObject.Find("Director").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;
    }
}

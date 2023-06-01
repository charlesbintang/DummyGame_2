using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Director : MonoBehaviour
{
    float yRotation = -80f;
    private NavMeshAgent navMeshAgent;
    EnemyNavMesh enemyNavMesh;
    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.CompareTag("Director"))
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            enemyNavMesh = GetComponent<EnemyNavMesh>();
            navMeshAgent.enabled = false;
            enemyNavMesh.enabled = false;
            gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);
        }
    }
}

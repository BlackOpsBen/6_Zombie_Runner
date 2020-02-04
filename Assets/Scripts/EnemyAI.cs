using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float pursuitRange = 10f;
    [SerializeField] bool isPursuing = false;
    [SerializeField] Color selectionColor = Color.red;
    float gizmoSize;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        gizmoSize = chaseRange;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget < chaseRange)
        {
            isPursuing = true;
        }
        if (distanceToTarget > pursuitRange)
        {
            isPursuing = false;
        }
        if (isPursuing)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (isPursuing)
        {
            gizmoSize = pursuitRange;
        }
        else
        {
            gizmoSize = chaseRange;
        }
        Gizmos.color = selectionColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}

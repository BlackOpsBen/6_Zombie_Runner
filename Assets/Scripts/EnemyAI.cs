using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float provokeRange = 5f;
    [SerializeField] float pursuitRange = 10f;
    [SerializeField] bool isProvoked = false;
    [SerializeField] Color selectionColor = Color.red;
    float gizmoSize;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        gizmoSize = provokeRange;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget < provokeRange)
        {
            isProvoked = true;
        }

        if (distanceToTarget > pursuitRange)
        {
            isProvoked = false;
        }

        if (isProvoked)
        {
            ChaseTarget();
        }
    }

    private void ChaseTarget()
    {
        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        else
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void AttackTarget()
    {
        print("You are being attacked!");
    }

    private void OnDrawGizmosSelected()
    {
        if (isProvoked)
        {
            gizmoSize = pursuitRange;
        }
        else
        {
            gizmoSize = provokeRange;
        }
        Gizmos.color = selectionColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}

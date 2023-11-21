using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform target;
    public float chaseDistance = 3f;
    public float returnDistance = 4f;

    int m_CurrentWaypointIndex;
    bool isChasing = false;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= chaseDistance)
            {
                navMeshAgent.SetDestination(target.position);
            }
            else if (distanceToTarget > returnDistance)
            {               
                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                {
                    m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                    navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                }
            }
        }
    }

  
}

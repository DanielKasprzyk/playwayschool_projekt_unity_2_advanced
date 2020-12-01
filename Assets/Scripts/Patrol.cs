using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    public int startPoint = 0;
    public float speed = 0.5f;
    public float distanceTreshold = 0.5f;

    private int selectedPoint;
    private NavMeshAgent agent;

    void Start()
    {
        selectedPoint = startPoint;
        agent = gameObject.GetComponent<NavMeshAgent>();

        ChangeEnabledState();
    }

    void Update()
    {
        ChangeEnabledState();

        GoToDestination();
    }

    public void GoToDestination()
    {
        if (agent.remainingDistance < distanceTreshold)
        {
            agent.destination = waypoints[selectedPoint].position;

            selectedPoint = GetNextDestinationPoint(selectedPoint, waypoints.Length);
        }
    }
    public int GetNextDestinationPoint(int point, int pointsCount)
    {
        return (point + 1) % pointsCount;
    }

    public void ChangeEnabledState()
    {
        if (waypoints.Length < 2)
        {
            enabled = false;
        }
        else
        {
            enabled = true;
        }
    }
}

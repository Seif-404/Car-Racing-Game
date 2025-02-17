using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AiController : MonoBehaviour
{
    public List<Transform> waypoints; // List of waypoints
    public float speed = 10f; // Speed at which the car moves
    public float turnSpeed = 5f; // Turn speed of the car
    public float waypointThreshold = 1f; // Distance threshold to detect if the car has reached the waypoint
    
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Count == 0) return;

        MoveCar();
    }

    void MoveCar()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Calculate direction to the waypoint
        Vector3 direction = targetWaypoint.position - transform.position;
        direction.y = 0; // Keep the car on the same horizontal plane

        // If the car is not facing the correct direction, rotate it towards the waypoint
        if (direction.magnitude > waypointThreshold)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            // If the car is close to the waypoint, move to the next one
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0; // Loop back to the first waypoint
            }
        }
    }
    
}

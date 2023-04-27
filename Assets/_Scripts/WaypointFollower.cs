using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private Rigidbody2D rb;

    [SerializeField] private float speed = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //Debug.Log(waypoints[currentWaypointIndex].transform.position);
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        transform.up = (waypoints[currentWaypointIndex].transform.position - transform.position).normalized;
        rb.velocity = transform.up * speed;
    }
}

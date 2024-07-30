using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugEnemyWaypoint : MonoBehaviour
{
    public Transform[] waypoint;

    [SerializeField] private int _speed = 1;
    [SerializeField] private int _maxSpeed = 1;

    private bool isAttacking = false;
    private GameObject player = null;

    private int waypointIndex;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoint[waypointIndex].position);
        player = GameObject.FindGameObjectWithTag("Player");
        _speed = _maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking == false)
        {
            dist = Vector3.Distance(transform.position, waypoint[waypointIndex].position);
            if (dist < 1f)
            {
                IncreaseIndex();
            }
            Patrol();
        }
    }
    void Patrol()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;

        if(waypointIndex >= waypoint.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoint[waypointIndex].position);
    }

    public void stopMoving()
    {
        isAttacking = true;
        _speed = 0;
        transform.LookAt(player.transform.position);
    }

    public void resumeMoving()
    {
        transform.LookAt(waypoint[waypointIndex].position);
        _speed = _maxSpeed;
        isAttacking = false;
    }

}


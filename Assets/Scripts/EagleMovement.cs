using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;
    [SerializeField]
    private float nextWaypointDist = 3f;

    private Transform target;
    private Path path;
    private int currentWaypoint = 0;
    private bool endOfPath = false; 

    private Seeker seeker;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private PlayerControl pl;
    private Transform playerPos;
    private CircleCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<CircleCollider2D>();
        pl = FindObjectOfType<PlayerControl>();
        playerPos = pl.transform;
        target = playerPos;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    private void isDone(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, isDone);
        }
    }

    private void FixedUpdate()
    {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            endOfPath = true;
            return;
        }
        else
        {
            endOfPath = false;
        }

        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;
        rb.AddForce(force);

        float dist = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (dist < nextWaypointDist)
        {
            currentWaypoint++;
        }

        if (force.x <= 0.01f)
        {
            sr.flipX = false;
            coll.offset = new Vector2(-0.3f, 0f); 
        }
        else if (force.x >= -0.01f)
        {
            sr.flipX = true;
            coll.offset = new Vector2(0.2f, 0f);
        }
    }
}

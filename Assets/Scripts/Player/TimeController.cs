using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public List<PointInTime> points = new List<PointInTime>();
    bool rewinding = false;

    private PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        HandleTime();
    }

    private void FixedUpdate()
    {
        if (rewinding)
            Rewind();
        else
            HandlePoints();
    }

    private void Rewind()
    {
        if (points.Count > 0)
        {
            transform.position = points[0].position;
            transform.rotation = points[0].rotation;
            points.RemoveAt(0);
        }
        else
            StopRewinding();
    }

    private void HandleTime()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewinding();
        }
    }

    private void StartRewinding() 
    {
        rewinding = true;
        playerMove.canMove = false;
    }

    private void StopRewinding() 
    {
        rewinding = false;
        playerMove.canMove = true;
    }

    private void HandlePoints()
    {
            PointInTime point = new PointInTime(transform.position, transform.rotation);
            points.Insert(0, point);
    }
}

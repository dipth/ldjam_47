using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public event Action OnTimeRewind;

    public List<PointInTime> points = new List<PointInTime>();
    public bool rewinding = false;

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
        if (OnTimeRewind != null)
        OnTimeRewind.Invoke();
        
        rewinding = true;
    }

    private void StopRewinding() 
    {
        rewinding = false;
    }

    private void HandlePoints()
    {
        PointInTime point = new PointInTime(transform.position, transform.rotation);
        points.Insert(0, point);
    }
}

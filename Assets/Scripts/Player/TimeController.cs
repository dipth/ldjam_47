using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public event Action OnTimeRewind;
    public event Action OnTimeDoneRewind;

    public List<PointInTime> points = new List<PointInTime>();
    public bool rewinding = false;

    private void Awake()
    {
        TimeManager.instance.OnTimesUp += HandleTime;
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
        StartRewinding();
    }

    public void StartRewinding() 
    {
        rewinding = true;

        if (OnTimeRewind != null)
            OnTimeRewind.Invoke();
    }

    private void StopRewinding() 
    {
        rewinding = false;

        if (OnTimeDoneRewind != null)
            OnTimeDoneRewind.Invoke();
    }

    private void HandlePoints()
    {
        PointInTime point = new PointInTime(transform.position, transform.rotation);
        points.Insert(0, point);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public event Action OnTimesUp;

    public float timeToRewind = 30;

    public Stopwatch stopwatch = new Stopwatch();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();
        CheckTime();
    }

    public void StartTimer() 
    {
        stopwatch.Start();
    }

    void StopTimer() 
    {
        stopwatch.Reset();
    }

    void CheckTime() 
    {
        if (stopwatch.ElapsedMilliseconds > timeToRewind)
        {
            StopTimer();
            RewindTime();
            //UnityEngine.Debug.Log("Times up");
        }
    }

    public void RewindTime() 
    {
        if (OnTimesUp != null)
            OnTimesUp.Invoke();
    }
}

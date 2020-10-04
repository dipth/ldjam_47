using Kino;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public event Action OnTimesUp;

    public float timeToRewind = 30;

    public Stopwatch stopwatch = new Stopwatch();

    public bool runTime = true;
    public float timeScale;

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

    void Update()
    {
        if (runTime)
            CheckTime();
    }

    public void StartTimer() 
    {
        stopwatch.Start();
    }

    public void StopTimer() 
    {
        stopwatch.Stop();
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

        UnityEngine.Debug.Log("TimesUp");
    }
}

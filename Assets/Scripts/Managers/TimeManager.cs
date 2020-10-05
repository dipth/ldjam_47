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

    public AnalogGlitch cameraGlitch;
    public float glitchTimeFactor;
    private float switchTime;

    Coroutine coroutine;


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

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartTimer() 
    {
        switchTime = Time.time;
        coroutine = StartCoroutine(GlitchEffect());
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

        //UnityEngine.Debug.Log("TimesUp");
    }

    IEnumerator GlitchEffect() 
    {
        float waitTime = (timeToRewind - 4000) / 1000;
        yield return new WaitForSeconds(waitTime);

        float intensity = 0f;

        while (intensity < 0.1f)
        {
            float time = (Time.time - switchTime) * glitchTimeFactor;
            intensity = Mathf.Lerp(0.0f, 0.1f, time);
            cameraGlitch.scanLineJitter = intensity * 2;
            cameraGlitch.colorDrift = intensity*.75f;

            yield return new WaitForEndOfFrame();
        }
    }

    public void StopGlitchEffect() 
    {
        StopCoroutine(coroutine);
        cameraGlitch.scanLineJitter = 0;
        cameraGlitch.colorDrift = 0;
    }
}

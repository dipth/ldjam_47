using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public float timeToRewind = 30;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer() 
    {
    
    }

    public void StopTimer() 
    {
    
    }

    public void RewindTime() 
    {
    
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public event Action OnTimeRewind;
    public event Action OnTimeDoneRewind;

    public event Action OnPlayerReset;

    public bool rewinding = false;

    PlayerMove playerMove;

    private void Awake()
    {
        TimeManager.instance.OnTimesUp += HandleTime;
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    private void FixedUpdate()
    {
    }

    IEnumerator ResetPlayer() 
    {
        playerMove.DisableCharacterController();


        yield return new WaitForSeconds(1f);
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
}

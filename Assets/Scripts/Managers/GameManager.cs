using Kino;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Transform> wayPoints = new List<Transform>();
    public int currentWaypointIndex = 0;
    public float ResetTimer = 1f;

    private PlayerMove playerMove;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    private void Start()
    {
        TimeManager.instance.OnTimesUp += ResetPlayer;
    }

    public void ResetPlayer() 
    {
        StartCoroutine(ResetPlayerRoutine());
    }

    IEnumerator ResetPlayerRoutine() 
    {
        playerMove.canMove = false;
        playerMove.ResetVelocity();
        
        GhostManager.instance.DisableGhostVisuals();
        GhostManager.instance.CreateGhost(playerMove.points);

        playerMove.ResetPosition(wayPoints[currentWaypointIndex].position, wayPoints[currentWaypointIndex].rotation);

        yield return new WaitForSeconds(.3f);

        TimeManager.instance.StopGlitchEffect();

        yield return new WaitForSeconds(1.7f);

        GhostManager.instance.ResetGhosts();

        GhostManager.instance.EnableGhostVisuals();
        
        yield return new WaitForSeconds(.45f);
        GhostManager.instance.EnableGhosts();
        TimeManager.instance.StartTimer();
        playerMove.canMove = true;
    }

    public void NewWaypoint(int newIndex) 
    {
        currentWaypointIndex = newIndex;
        GhostManager.instance.GhostBusters();
        playerMove.ClearPath();
        TimeManager.instance.StopGlitchEffect();
    }
}

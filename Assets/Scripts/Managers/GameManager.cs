using System.Collections;
using System.Collections.Generic;
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
        playerMove.DisableCharacterController();
        GhostManager.instance.CreateGhost(playerMove.points);

        //Run glitchAnimation

        yield return new WaitForSeconds(ResetTimer);
        playerMove.ResetPosition(wayPoints[currentWaypointIndex].position, wayPoints[currentWaypointIndex].rotation);

        //Run something here ?

        yield return new WaitForSeconds(ResetTimer);
        playerMove.EnableCharacterController();
        GhostManager.instance.ResetGhosts();
        GhostManager.instance.EnableGhosts();
    }

    public void NewWaypoint(int newIndex) 
    {
        currentWaypointIndex = newIndex;
        GhostManager.instance.GhostBusters();
        playerMove.ClearPath();
    }
}

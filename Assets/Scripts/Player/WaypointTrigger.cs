using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTrigger : MonoBehaviour
{
    public int index;
    public float roomTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.NewWaypoint(index);
            TimeManager.instance.StopTimer();
            TimeManager.instance.timeToRewind = roomTimer;
            TimeManager.instance.StartTimer();

            Destroy(this.gameObject);
        }
    }
}

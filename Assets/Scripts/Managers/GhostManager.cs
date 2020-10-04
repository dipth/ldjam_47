using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public static GhostManager instance;

    List<Ghost> ghosts = new List<Ghost>();

    public Ghost ghostPrefab;
    public Transform ghostParent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void AddGhostToList(Ghost ghost)
    {
        ghosts.Add(ghost);
    }

    public void ResetGhosts()
    {
        if (ghosts.Count > 0)
        {
            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts[i].transform.position = GameManager.instance.wayPoints[GameManager.instance.currentWaypointIndex].position;
                ghosts[i].pathIndex = 0;
            }
        }
    }

    public void DisableGhostVisuals()
    {
        if (ghosts.Count > 0)
        {
            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts[i].Sr.enabled = false;
            }
        }
    }

    public void EnableGhostVisuals()
    {
        if (ghosts.Count > 0)
        {
            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts[i].Sr.enabled = true;
            }
        }
    }

    public void EnableGhosts() 
    {
        if (ghosts.Count > 0)
        {
            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts[i].canMove = true;
            }
        }
    }

    public void GhostBusters() 
    {
        for (int i = 0; i < ghosts.Count; i++)
        {
            Destroy(ghosts[i].gameObject);
        }
        ghosts.Clear();
    }

    public void CreateGhost(List<PointInTime> _points)
    {
        Ghost clone;
        clone = Instantiate(ghostPrefab, transform.position, Quaternion.identity, ghostParent);
        clone.AddPath(_points);
        AddGhostToList(clone);
        ResetGhosts();
    }
}

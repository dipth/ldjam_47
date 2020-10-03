using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public static GhostManager instance;
    List<Ghost> ghosts = new List<Ghost>();

    public Ghost ghostPrefab;
    public Transform ghostParent;
    TimeController timeController;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        timeController = GameObject.FindGameObjectWithTag("Player").GetComponent<TimeController>();
        timeController.OnTimeRewind += CreateGhost;
    }

    public void AddGhostToList(Ghost ghost) 
    {
        ghosts.Add(ghost);
    }

    public void GhostBusters() 
    {
        for (int i = 0; i < ghosts.Count; i++)
        {
            Destroy(ghosts[i].gameObject);
        }
        ghosts.Clear();
    }

    public void CreateGhost()
    {
        Ghost clone;
        clone = Instantiate(ghostPrefab, transform.position, Quaternion.identity, ghostParent);
        clone.AddPath(timeController.points);
        GhostManager.instance.AddGhostToList(clone);
    }
}

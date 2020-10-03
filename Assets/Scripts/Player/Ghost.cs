using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    PointInTime[] path;

    public MeshRenderer mr;
    public GameObject lightSource;

    public bool canMove = false;
    public int pathIndex;

    private void Update()
    {
        if (canMove)
        {
            FollowPath();
        }
    }

    public void AddPath(List<PointInTime> _path) 
    {
        path = new PointInTime[_path.Count];
        _path.CopyTo(path);
    }

    void FollowPath() 
    {
        if (path.Length > 0)
        {
            if (pathIndex > (path.Length-1))
                return;

            transform.position = path[pathIndex].position;
            pathIndex++;
        }
    }

    public void EnableVisuals() 
    {
        mr.enabled = true;
        lightSource.SetActive(true);
    }
}

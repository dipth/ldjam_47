using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    PointInTime[] path;

    public bool canMove = false;

    private void FixedUpdate()
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
        Array.Reverse(path);
    }

    void FollowPath() 
    {
        if (path.Length > 0)
        {
                    
        }
    }
}

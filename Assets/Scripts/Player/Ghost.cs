using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    PointInTime[] path;

    public SpriteRenderer Sr;
    public GameObject lightSource;

    public bool canMove = false;
    public int pathIndex;

    public Animator animator;
    public Rigidbody rigidbody;

    private Vector3 previous;
    private Vector3 current;

    private void Update()
    {
        if (canMove)
        {
            FollowPath();
        }

        HandleAnimation();
    }
    private void LateUpdate()
    {
        previous = transform.position;
    }

    private void HandleAnimation()
    {
        current = transform.position;
        var velocity = (current - previous) / Time.deltaTime;
        animator.SetFloat("xVel", velocity.x);
        animator.SetFloat("zVel", velocity.z);
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
        Sr.enabled = true;
        lightSource.SetActive(true);
    }
}

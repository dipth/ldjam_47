using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed;
    [HideInInspector]public bool canMove;

    public List<PointInTime> points = new List<PointInTime>();
    private CharacterController characterController;
    private Vector3 moveDir;
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.enabled)
        {
            HandleInput();
            HandleMove();
            HandlePoints();
        }
    }

    void HandleInput() 
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(x, 0, z).normalized;
    }
    void HandleMove() 
    {
        characterController.Move(moveDir * Time.deltaTime * playerSpeed);
    }
    private void HandlePoints()
    {
        PointInTime point = new PointInTime(transform.position, transform.rotation);
        points.Add(point);
    }

    public void DisableCharacterController()
    {
        characterController.enabled = false;    
    }
    public void EnableCharacterController() 
    {
        characterController.enabled = true;
    }

    public void ResetPosition(Vector3 newPos, Quaternion newRot) 
    {
        transform.position = newPos;
        transform.rotation = newRot;
        points.Clear();
    }

    public void ClearPath() 
    {
        points.Clear();
    }
}

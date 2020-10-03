using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed;
    [HideInInspector]public bool canMove;

    private CharacterController characterController;
    private TimeController timeController;
    private Vector3 playerVelocity;
    private Vector3 moveDir;
    private bool groundedPlayer;
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        timeController = GetComponent<TimeController>();
    }

    void Update()
    {
        HandleCharacterController();

        if (characterController.enabled)
            HandleInput();

        HandleMove();
    }

    private void HandleCharacterController()
    {
        if (timeController.rewinding)
            characterController.enabled = false;
        else
            characterController.enabled = true;
    }

    void HandleInput() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDir = new Vector3(x, 0, z).normalized;
    }
    void HandleMove() 
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        characterController.Move(moveDir * Time.deltaTime * playerSpeed);
    }
}

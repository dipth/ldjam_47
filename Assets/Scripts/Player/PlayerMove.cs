using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed;
    [HideInInspector]public bool canMove;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private Vector3 moveDir;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    // Start is called before the first frame update
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCharacterController();

        if (canMove)
        {
            HandleInput();
            HandleMove();
        }
    }

    private void HandleCharacterController()
    {
        if (canMove)
            characterController.enabled = true;
        else
            characterController.enabled = false;
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

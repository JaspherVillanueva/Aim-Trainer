using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to handle the movement of the player model. Allowing the user to walk around the environment.

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private float speed = 12f;
    private float jumpHeight = 3f;
    private float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        //checks if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            //gravity
            velocity.y = -3f;
        }

        //move left/right
        float x = Input.GetAxis("Horizontal");
        //move forward/back
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //Debug.Log("Moved player");

        controller.Move(move * speed * Time.deltaTime);

        //if jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //then jump and fall
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

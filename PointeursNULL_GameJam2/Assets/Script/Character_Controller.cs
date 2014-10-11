﻿using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour
{
    private float Speed = 10f;
    private float jumpSpeed = 15f;
    private float Gravity = 20f;
    
    CharacterController Controller;
    private bool facingRight = true;
    Vector3 moveDirection = Vector3.zero;
    private float Ymove;


    private bool Button1Down;
    private bool Button2Down;

    void Update()
    {
        DpadButton();
        Triggers();
    }

    void FixedUpdate()
    {
        Controller = GetComponent<CharacterController>();
		if (Controller.isGrounded) 
        {
			// We are grounded, so recalculate
			// move direction directly from axes
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= Speed;

            if (Input.GetButton("Jump"))
            {
                Ymove = jumpSpeed;
            }
            else
            {
                Ymove = 0;
            }
		}

        Ymove -= Gravity * Time.deltaTime;
        moveDirection.y = Ymove;
        Controller.Move(moveDirection * Time.deltaTime);
    }

    void Triggers()
    {

    }

    void DpadButton()
    {
        if (Input.GetAxis("PowerUp1") == 0) Button1Down = false;
        else if (Input.GetAxis("PowerUp1") == 1 && !Button1Down)
        {
            Button1Down = true;
            Debug.Log("Power Up 1");
        }
        else if (Input.GetAxis("PowerUp1") == -1 && !Button1Down)
        {
            Button1Down = true;
            Debug.Log("Power Up 2");
        }

        if (Input.GetAxis("PowerUp2") == 0) Button2Down = false;
        else if (Input.GetAxis("PowerUp2") == 1 && !Button2Down)
        {
            Button2Down = true;
            Debug.Log("Power Up 3");
        }
        else if (Input.GetAxis("PowerUp2") == -1 && !Button2Down)
        {
            Button2Down = true;
            Debug.Log("Power Up 4");
        }
    }
}

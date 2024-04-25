using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    private CharacterController _controller;
    private const float GravityValue = -9.81f;

    // private void Awake()
    // {
    //     _controller.enabled = true;
    // }

    private void Start()
    {
       // _controller = GetComponent<CharacterController>();

        // _controller = GetComponent<CharacterController>();
        // _controller.enabled = true;
    }

    public void UpdateMovement(Vector3 playerVelocity, Vector3 movementVector)
    {


        Debug.Log("WHY");
        if (_controller != null)
        {
            if (movementVector != Vector3.zero)
            {
                gameObject.transform.forward = movementVector;
            }

            playerVelocity.y += GravityValue * Time.deltaTime;
            _controller.Move(playerVelocity * Time.deltaTime);
        }
    }

}

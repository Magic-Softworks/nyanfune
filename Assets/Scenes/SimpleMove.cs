using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed

    private CharacterController controller;

    void Start()
    {
        // Get the CharacterController component attached to this object
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input from the horizontal and vertical axis (WASD and arrow keys)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        // Move the character
        controller.Move(Time.deltaTime * speed * movement);
    }
}
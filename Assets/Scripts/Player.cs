using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the character movement

    void Update()
    {
        // Get the input from arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Invert the input values to move in the correct direction
        moveHorizontal *= -1f;
        moveVertical *= -1f;

        // Calculate the movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the character based on the input
        transform.Translate(movement * speed * Time.deltaTime);
    }
}

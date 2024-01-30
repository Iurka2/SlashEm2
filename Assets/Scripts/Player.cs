using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    private bool isRolling = false;
    private float rollDuration = 0.5f; // Adjust as needed
    private float rollTimer = 0f;
    private Vector3 rollDirection;

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (!isRolling)
        {
            if (Input.GetKey(KeyCode.W))
            {
                inputVector.y = +1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputVector.y = -1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputVector.x = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputVector.x = +1;
            }

            inputVector = inputVector.normalized;

            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.position += moveSpeed * Time.deltaTime * moveDir;

            if (moveDir != Vector3.zero)
            {
                float rotateSpeed = 10f;
                transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
            }
        }
        else
        {
            // Rolling, update rollTimer and roll the player
            rollTimer -= Time.deltaTime;
            if (rollTimer <= 0f)
            {
                isRolling = false;
            }
            else
            {
                transform.position += moveSpeed * Time.deltaTime * rollDirection;
            }
        }

        handleRoll();
    }

    private void handleRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            // Start roll animation
            isRolling = true;
            rollTimer = rollDuration;
            rollDirection = transform.forward; // Rolling direction is the current facing direction
        }
    }
}

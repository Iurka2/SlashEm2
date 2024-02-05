using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float runSpeed = 20f;
    [SerializeField] private GameInput gameInput;



    private bool isWalking;


    private void Update()
    {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        float playerSize = .7f;
        
        bool canMove =  !Physics.Raycast(transform.position, moveDir, playerSize);



        if (!canMove)
        {
            //Cannot move toweds moveDRI
            //

            //atempt X

            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.Raycast(transform.position, moveDirX, playerSize);

            if (canMove)
            {
                moveDir = moveDirX * 2;
            }
            else
            {
               //atempt Z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.Raycast(transform.position, moveDirZ, playerSize);
                if (canMove)
                {
                    moveDir = moveDirZ  * 2;
                }
                else
                {

                }
            }
        } 

 

        if (canMove)
        {
            transform.position += moveSpeed * Time.deltaTime * moveDir;
        }


        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }



    public bool IsWalking()
    {
        return isWalking;
    }


}
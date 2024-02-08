using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
//c [SerializeField] private float runSpeed = 20f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask wallLayerMask;


    private bool isWalking;
    private Vector3 lastInteracDir;



    private void Start()
    {
        gameInput.onInteractAction += GameInput_onInteractAction;
    }

    private void GameInput_onInteractAction(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        if (moveDir != Vector3.zero)
        {
            lastInteracDir = moveDir;
        }


        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteracDir, out RaycastHit raycastHit, interactDistance, wallLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Wall Wall))
            {
                Wall.Interact();
            }
        }
    }

    private void Update()
    {
        HadleMovement();
        HandleInteraction();
    }

    public bool IsWalking() {
        return isWalking;
    }


    private void HandleInteraction() {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        if (moveDir != Vector3.zero) {
            lastInteracDir = moveDir;
        } 


        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteracDir, out RaycastHit raycastHit, interactDistance,wallLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out Wall Wall))
            {
            }
        } 

    }
    private void HadleMovement() {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 1f;
        float playerHeight = 2f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);



        if (!canMove)
        {
            //Cannot move toweds moveDRI
            //

            //atempt X

            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                //atempt Z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {

                }
            }
        }



        if (canMove)
        {
            transform.position += moveDir * moveDistance  ;
        }


        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }


 
}
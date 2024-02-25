using System;
using UnityEngine;

public class Player : MonoBehaviour,IWeaponParent {

    public static Player Instance { get; private set; }

    public event EventHandler <OnSlectedWallChangeEventArgs> OnSlectedWallChange;
    public class OnSlectedWallChangeEventArgs : EventArgs {
        public CleanWall selectedWall;
    }

    [SerializeField] private float moveSpeed = 7f;
    //c [SerializeField] private float runSpeed = 20f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private Transform SpawnPoint;

    private bool isWalking;
    private Vector3 lastInteracDir;
    private CleanWall selectedWall;
    private WeaponObject weaponObject;

    private void Awake() {
        if (Instance != null) {
            Debug.Log("bad");
        }

        Instance = this;
    }

    private void Start() {
        gameInput.onInteractAction += GameInput_onInteractAction;
    }

    private void GameInput_onInteractAction(object sender, System.EventArgs e) {
        if (selectedWall != null) {
            selectedWall.Interact(this);
        }
    }

    private void Update() {
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
        RaycastHit raycastHit;

        // Perform the raycast
        if (Physics.Raycast(transform.position, lastInteracDir, out raycastHit, interactDistance, wallLayerMask)) {
            if (raycastHit.transform.TryGetComponent(out CleanWall cleanWall)) {
                // Check if the wall is different from the current selected wall
                if (cleanWall != selectedWall) {
                    SetSelectedWall(cleanWall);
                }
                // Optionally, you can add a condition here to handle interactions with the same wall
            }
        }
        else {
            // If the raycast doesn't hit anything, check if the previous selected wall is still within range
            if (selectedWall != null) {
                // Check if the previous selected wall is still within range
                float distanceToPreviousWall = Vector3.Distance(selectedWall.transform.position, transform.position);
                if (distanceToPreviousWall > interactDistance) {
                    // If the previous selected wall is no longer within range, deselect it
                    SetSelectedWall(null);
                }
            }
        }
    }
    private void HadleMovement() {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.65f;
        float playerHeight = 1f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);



        if (!canMove) {
            //Cannot move toweds moveDRI
            //

            //atempt X

            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove) {
                moveDir = moveDirX;
            }
            else {
                //atempt Z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove) {
                    moveDir = moveDirZ;
                }
                else {

                }
            }
        }



        if (canMove) {
            transform.position += moveDir * moveDistance;
        }


        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);



    }

    private void SetSelectedWall(CleanWall selectedWall) {
        this.selectedWall = selectedWall;

        OnSlectedWallChange?.Invoke(this, new OnSlectedWallChangeEventArgs {
            selectedWall = selectedWall
        });
    }

    public Transform GetWeaponObjectFollowTransofrm ( ) {
        return SpawnPoint;
    }

    public void setWeaponObject ( WeaponObject weaponObject ) {
        this.weaponObject = weaponObject;
    }

    public WeaponObject GetWeaponObject ( ) {
        return weaponObject;
    }

    public void ClearWeaponObject ( ) {
        weaponObject = null;
    }

    public bool HasWeaponObject ( ) {
        return weaponObject != null;
    }
}
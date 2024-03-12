using UnityEngine;

public class WeaponObject : MonoBehaviour
{

    [SerializeField] private WeaponSS weaponSS;

    private IWeaponParent weaponObjectParent;

    public WeaponSS GetWeaponSS() {
        return weaponSS;
    }

/*    public bool IsOnGround ( ) {
        float groundCheckDistance = 0.5f;  // Adjust as needed
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }*/

    public void SetWeaponObjectParent(IWeaponParent weaponObjectParent) {
        if(this.weaponObjectParent != null) {
            this.weaponObjectParent.ClearWeaponObject();
        }

        this.weaponObjectParent = weaponObjectParent;
        if (weaponObjectParent.HasWeaponObject()) {
            weaponObjectParent.GetWeaponObject().DropWeapon();
           
        }

        weaponObjectParent.setWeaponObject(this);
        transform.parent = weaponObjectParent.GetWeaponObjectFollowTransofrm();
        transform.localPosition = Vector3.zero;

    }

    public void DropWeapon () {

        weaponObjectParent = null; // Clear weapon parent
        transform.parent = null; // Detach from any parent

        gameObject.AddComponent<Rigidbody>(); // Add physics for dropping effect (adjust colliders if needed)
     /*   RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit)) {
            transform.parent = hit.transform; // Assign the hit object as the parent
        }*/

    }





    public IWeaponParent GetWeaponParent () {
        return weaponObjectParent;
    }
}

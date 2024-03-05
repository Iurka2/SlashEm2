using UnityEngine;

public class WeaponObject : MonoBehaviour
{

    [SerializeField] private WeaponSS weaponSS;

    private IWeaponParent weaponObjectParent;

    public WeaponSS GetWeaponSS() {
        return weaponSS;
    }

  

    public void SetWeaponObjectParent(IWeaponParent weaponObjectParent) {
        if(this.weaponObjectParent != null) {
            this.weaponObjectParent.ClearWeaponObject();
        }

        this.weaponObjectParent = weaponObjectParent;
        if (weaponObjectParent.HasWeaponObject()) {
            weaponObjectParent.GetWeaponObject().DropWeapon();
            Debug.Log(weaponObjectParent);
        }

        weaponObjectParent.setWeaponObject(this);
        transform.parent = weaponObjectParent.GetWeaponObjectFollowTransofrm();
        transform.localPosition = Vector3.zero;

    }
    private string weaponLayerName = "Pistol";
    public void DropWeapon ( ) {
        
        weaponObjectParent = null; // Clear weapon parent
        gameObject.layer = LayerMask.NameToLayer(weaponLayerName); // Make interactable
        gameObject.AddComponent<Rigidbody>(); // Add physics for dropping effect (adjust colliders if needed)
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit)) {
            transform.parent = hit.transform; // Assign the hit object as the parent
        }
        Debug.Log(weaponObjectParent);
     
    }

    public IWeaponParent GetWeaponParent () {
        return weaponObjectParent;
    }
}

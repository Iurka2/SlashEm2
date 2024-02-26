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
            Debug.LogError("wall has gun dumbass ");
        }
        weaponObjectParent.setWeaponObject(this);

        transform.parent = weaponObjectParent.GetWeaponObjectFollowTransofrm();
        transform.localPosition = Vector3.zero;
    }

    public IWeaponParent GetWeaponParent () {
        return weaponObjectParent;
    }
}

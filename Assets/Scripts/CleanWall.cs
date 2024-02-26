using UnityEngine;

public class CleanWall : MonoBehaviour,IWeaponParent {

    [SerializeField] private WeaponSS M1911;
    [SerializeField] private Transform SpawnPoint;


    private WeaponObject weaponObject;

 
    public void Interact(Player player) {
        if (weaponObject == null) {

         Transform weaponTransform = Instantiate(M1911.prefab, SpawnPoint);
         weaponTransform.GetComponent<WeaponObject>().SetWeaponObjectParent(this);

        } else {
            //Give it to the player
            weaponObject.SetWeaponObjectParent(player);
         
        }
    }

    public Transform GetWeaponObjectFollowTransofrm ( ) {
        return SpawnPoint;
    }

    public void setWeaponObject(WeaponObject weaponObject ) {
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

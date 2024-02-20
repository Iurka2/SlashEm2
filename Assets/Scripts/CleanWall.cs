using UnityEngine;

public class CleanWall : MonoBehaviour {

    [SerializeField] private WeaponSS M1911;
    [SerializeField] private Transform SpawnPoint;


    private WeaponObject weaponObject;
    public void Interact() {
        if (weaponObject == null) {
            
        Transform weaponTransform = Instantiate(M1911.prefab, SpawnPoint);
        weaponTransform.localPosition = Vector3.zero;

        weaponObject = weaponTransform.GetComponent<WeaponObject>();
            weaponObject.SetCleanWall(this);

        } else {
            Debug.Log(weaponObject.GetCleanWall());
        }
    }

}

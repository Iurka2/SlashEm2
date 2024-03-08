using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefab : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayerMask;

    [SerializeField] private WeaponSS weapon;
    [SerializeField] private Transform SpawnPoint;

    private Rigidbody rb;
    private WeaponObject weaponObject;







    public void Interact ( Player player ) {
        if(weaponObject == null) {

            Transform weaponTransform = Instantiate(weapon.prefab, SpawnPoint);
            weaponTransform.GetComponent<WeaponObject>().SetWeaponObjectParent(player);

        } else {
            //Give it to the player
            weaponObject.SetWeaponObjectParent(player);

        }
    }

    void Start () {
            rb = GetComponent<Rigidbody>();
        }

        void OnTriggerEnter(Collider other) {
            // Check if the collided object is on the "Table" layer
            if (other.gameObject.layer == wallLayerMask) {
                // Stop the pistol from moving
                rb.isKinematic = true;
            }
        }


    
}

using UnityEngine;

public class CleanWall : MonoBehaviour {

    [SerializeField] private WeaponSS M1911;
    [SerializeField] private Transform SpawnPoint;
    public void Interact() {
        Transform weaponTransform = Instantiate(M1911.prefab, SpawnPoint);
        weaponTransform.localPosition = Vector3.zero;

        Debug.Log(weaponTransform.GetComponent<WeaponObject>().GetWeaponSS().objectName);

    }

}

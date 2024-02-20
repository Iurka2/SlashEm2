using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{

    [SerializeField] private WeaponSS weaponSS;

    public WeaponSS GetWeaponSS() {
        return weaponSS;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{

    [SerializeField] private WeaponSS weaponSS;

    private CleanWall cleanWall;

    public WeaponSS GetWeaponSS() {
        return weaponSS;
    }

    public void SetCleanWall(CleanWall cleanWall ) {
        this.cleanWall = cleanWall;
    }

    public CleanWall GetCleanWall ( ) {
        return cleanWall;
    }
}

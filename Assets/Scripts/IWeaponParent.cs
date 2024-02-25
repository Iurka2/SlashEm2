using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponParent {

    public Transform GetWeaponObjectFollowTransofrm ( );
    public void setWeaponObject ( WeaponObject weaponObject );

    public WeaponObject GetWeaponObject();

    public void ClearWeaponObject ();
    public bool HasWeaponObject ();
    }


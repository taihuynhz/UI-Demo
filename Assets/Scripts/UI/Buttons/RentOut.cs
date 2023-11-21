using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentOut : BaseButton
{
    protected void Start()
    {
        if (button == null) return;

        button.onClick.AddListener( () => { SetRentOut(); });
    }

    public void SetRentOut()
    {
        if (WeaponButtonManager.Instance.currentWeaponButton == null) return;

        WeaponButtonManager.Instance.currentWeaponButton.SetRendedOutWeapon();
    }
}

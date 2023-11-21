using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : BaseButton
{
    protected void Start()
    {
        if (button == null) return;

        button.onClick.AddListener( () => { SetUse(); } );
    }

    public void SetUse()
    {
        if (WeaponButtonManager.Instance.currentWeaponButton == null) return;

        WeaponButtonManager.Instance.currentWeaponButton.SetUsedWeapon();
    }
}

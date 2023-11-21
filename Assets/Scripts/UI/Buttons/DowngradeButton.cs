using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowngradeButton : BaseButton
{
    protected void Start()
    {
        if (button == null) return;

        button.onClick.AddListener(() => { SetDowngrade(); });
    }

    public void SetDowngrade()
    {
        if (WeaponButtonManager.Instance.currentWeaponButton == null) return;

        WeaponButtonManager.Instance.currentWeaponButton.DowngradeWeapon();
    }
}

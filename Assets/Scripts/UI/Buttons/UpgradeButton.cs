using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : BaseButton
{
    protected void Start()
    {
        if (button == null) return;

        button.onClick.AddListener(() => { SetUpgrade(); });
    }

    public void SetUpgrade()
    {
        if (WeaponButtonManager.Instance.currentWeaponButton == null) return;

        WeaponButtonManager.Instance.currentWeaponButton.UpgradeWeapon();
    }
}

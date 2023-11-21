using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryWeaponPanel : Singleton<PrimaryWeaponPanel>
{
    [Header("Primary Weapon Panel")]
    [SerializeField] protected Image primaryWeaponImage;
    [SerializeField] protected Text useButtonText;
    [SerializeField] protected Text rentOutButtonText;
    [SerializeField] protected Outline useButtonTextOutine;
    [SerializeField] protected Outline rentOutButtonTextOutine;
    [SerializeField] protected Color useButtonTextColor;
    [SerializeField] protected Color rentOutButtonTextColor;
    [SerializeField] protected Color disableColor = Color.gray;

    protected void Reset()
    {
        primaryWeaponImage = transform.Find("Gun_Image").GetComponent<Image>();
    }

    public void SetWeaponImage(WeaponData weaponData)
    {
        if (primaryWeaponImage == null) return;

        primaryWeaponImage.sprite = weaponData.weaponImage;
    }

    public void ChangeButtonTextToDisableColor()
    {
        if (useButtonText == null) return;
        if (rentOutButtonText == null) return;
        if (useButtonTextOutine == null) return;
        if (rentOutButtonTextOutine == null) return;

        useButtonText.color = disableColor;
        rentOutButtonText.color = disableColor;

        useButtonTextOutine.enabled = false;
        rentOutButtonTextOutine.enabled = false;
    }

    public void ChangeButtonTextToNormalColor()
    {
        if (useButtonText == null) return;
        if (rentOutButtonText == null) return;
        if (useButtonTextOutine == null) return;
        if (rentOutButtonTextOutine == null) return;

        useButtonText.color = useButtonTextColor;
        rentOutButtonText.color = rentOutButtonTextColor;

        useButtonTextOutine.enabled = true;
        rentOutButtonTextOutine.enabled = true;
    }
}

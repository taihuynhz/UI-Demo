using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryWeaponPanel : Singleton<PrimaryWeaponPanel>
{
    [Header("Primary Weapon Panel")]
    [SerializeField] protected Image primaryWeaponImage;
    [SerializeField] protected Button useButton;
    [SerializeField] protected Button rentOutButton;
    [SerializeField] protected Text useButtonText;
    [SerializeField] protected Text rentOutButtonText;
    [SerializeField] protected Outline useButtonTextOutine;
    [SerializeField] protected Outline rentOutButtonTextOutine;
    [SerializeField] protected Color useButtonTextColor = new Color32(0, 255, 72, 255); 
    [SerializeField] protected Color rentOutButtonTextColor = new Color32(255, 135, 38, 255);
    [SerializeField] protected Color disableColor = Color.gray;

    protected void Start()
    {
        RegisterOnClickEvent();
    }

    protected void RegisterOnClickEvent()
    {
        useButton.onClick.AddListener( () => { WeaponManager.Instance.selectedWeapon.SetUseWeapon(); } );
        rentOutButton.onClick.AddListener( () => { WeaponManager.Instance.selectedWeapon.SetRentWeapon(); } );
    }

    public void SetWeaponImage(WeaponData weaponData)
    {
        primaryWeaponImage.sprite = weaponData.weaponImage;
    }

    public void ChangeButtonTextToNormalColor()
    {
        useButtonText.color = useButtonTextColor;
        rentOutButtonText.color = rentOutButtonTextColor;
        useButtonTextOutine.enabled = true;
        rentOutButtonTextOutine.enabled = true;
    }

    public void ChangeRentOutButtonToDisableColor()
    {
        useButtonText.color = useButtonTextColor;
        rentOutButtonText.color = disableColor;
        useButtonTextOutine.enabled = true;
        rentOutButtonTextOutine.enabled = false;
    }

    public void ChangeUseButtonText(string text)
    {
        useButtonText.text = text;
    }

    public void ChangeRentButtonText(string text)
    {
        rentOutButtonText.text = text;
    }
}

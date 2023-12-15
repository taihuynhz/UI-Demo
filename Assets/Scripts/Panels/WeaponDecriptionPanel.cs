using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDecriptionPanel : Singleton<WeaponDecriptionPanel>
{
    [Header("Weapon Decription Panel")]
    [SerializeField] protected Button upgradeButton;
    [SerializeField] protected Button downgradeButton;
    [SerializeField] protected Text weaponNameText;
    [SerializeField] protected Text damageAmountText;
    [SerializeField] protected Text dispersionAmountText;
    [SerializeField] protected Text rateOfFireAmountText;
    [SerializeField] protected Text reloadSpeedAmountText;
    [SerializeField] protected Text ammunitionAmountText;
    [SerializeField] protected Text upgradeAmountText;

    protected void Start()
    {
        RegisterOnClickEvent();
    }

    protected void RegisterOnClickEvent()
    {
        upgradeButton.onClick.AddListener( () => { HandleUpgradeButton(); } );
        downgradeButton.onClick.AddListener( () => { HandleDowngradeButton(); } );
    }

    protected void HandleUpgradeButton() 
    {
        WeaponData selectedWeaponData = WeaponManager.Instance.selectedWeapon.data;
        if (selectedWeaponData.upgradeLevel >= selectedWeaponData.maxUpgradeLevel)
            PopupPanel.Instance.ShowPopupLog(PopupLog.WeaponMaxLevel);
        else
        {
            PopupPanel.Instance.ShowPopupPanel();
            PopupPanel.Instance.SetPopupPanelText(PopupPanelText.Upgrade);
            PopupPanel.yesAction = WeaponManager.Instance.selectedWeapon.UpgradeWeapon;
        }
    }

    protected void HandleDowngradeButton() 
    {
        WeaponData selectedWeaponData = WeaponManager.Instance.selectedWeapon.data;
        if (selectedWeaponData.upgradeLevel <= selectedWeaponData.minUpgradeLevel)
            PopupPanel.Instance.ShowPopupLog(PopupLog.WeaponMinLevel);
        else
        {
            PopupPanel.Instance.ShowPopupPanel();
            PopupPanel.Instance.SetPopupPanelText(PopupPanelText.Downgrade);
            PopupPanel.yesAction = WeaponManager.Instance.selectedWeapon.DowngradeWeapon;
        }
    }

    public void SetDecription(WeaponData weaponData)
    {
        weaponNameText.text = weaponData.weaponName;
        damageAmountText.text = weaponData.damage.ToString();
        dispersionAmountText.text = weaponData.dispersion.ToString();
        rateOfFireAmountText.text = weaponData.rateOfFire.ToString() + " RPM";
        reloadSpeedAmountText.text = weaponData.reloadSpeed.ToString() + "%";
        ammunitionAmountText.text = weaponData.ammunition.ToString() + "/" + weaponData.ammunition.ToString();
        //upgradeAmountText.text = weaponData.upgrade.ToString();
    }
}

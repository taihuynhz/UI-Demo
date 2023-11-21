using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDecriptionPanel : Singleton<WeaponDecriptionPanel>
{
    [Header("Weapon Decription Panel")]
    [SerializeField] protected Text weaponNameText;
    [SerializeField] protected Text damageAmountText;
    [SerializeField] protected Text dispersionAmountText;
    [SerializeField] protected Text rateOfFireAmountText;
    [SerializeField] protected Text reloadSpeedAmountText;
    [SerializeField] protected Text ammunitionAmountText;
    [SerializeField] protected Text upgradeAmountText;

    protected void Reset()
    {
        weaponNameText = GameObject.Find("WeaponName_Text").transform.GetComponent<Text>();
        damageAmountText = GameObject.Find("Damage_Panel").transform.Find("Amount_Text").GetComponent<Text>();
        dispersionAmountText = GameObject.Find("Disperion_Panel").transform.Find("Amount_Text").GetComponent<Text>();
        rateOfFireAmountText = GameObject.Find("Rate_of_fire_Panel").transform.Find("Amount_Text").GetComponent<Text>();
        reloadSpeedAmountText = GameObject.Find("Reload_speed_Panel").transform.Find("Amount_Text").GetComponent<Text>();
        ammunitionAmountText = GameObject.Find("Ammunition_Panel").transform.Find("Amount_Text").GetComponent<Text>();
        upgradeAmountText = GameObject.Find("Upgrade_Panel").transform.Find("Amount_Text").GetComponent<Text>();
    }

    protected void ClearText()
    {
        if (weaponNameText == null) return;
        if (damageAmountText == null) return;
        if (dispersionAmountText == null) return;
        if (rateOfFireAmountText == null) return;
        if (reloadSpeedAmountText == null) return;
        if (ammunitionAmountText == null) return;
        if (upgradeAmountText == null) return;

        weaponNameText.text = "";
        damageAmountText.text = "";
        dispersionAmountText.text = "";
        rateOfFireAmountText.text = "";
        reloadSpeedAmountText.text = "";
        ammunitionAmountText.text = "";
        upgradeAmountText.text = "";
    } 

    public void SetDecription(WeaponData weaponData)
    {
        if (weaponNameText == null) return;
        if (damageAmountText == null) return;
        if (dispersionAmountText == null) return;
        if (rateOfFireAmountText == null) return;
        if (reloadSpeedAmountText == null) return;
        if (ammunitionAmountText == null) return;
        if (upgradeAmountText == null) return;

        weaponNameText.text = weaponData.weaponName;
        damageAmountText.text = weaponData.damage.ToString();
        dispersionAmountText.text = weaponData.dispersion.ToString();
        rateOfFireAmountText.text = weaponData.rateOfFire.ToString() + " RPM";
        reloadSpeedAmountText.text = weaponData.reloadSpeed.ToString() + "%";
        ammunitionAmountText.text = weaponData.ammunition.ToString() + "/" + weaponData.magazine.ToString();
        //upgradeAmountText.text = weaponData.upgrade.ToString();
    }
}

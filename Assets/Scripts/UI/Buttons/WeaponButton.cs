using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : BaseButton
{
    [Header("Weapon Button")]
    [SerializeField] protected WeaponState weaponState = WeaponState.None;
    [SerializeField] protected GameObject selectedPanel;
    [SerializeField] protected GameObject textGameObject;
    [SerializeField] protected Text weaponStateText;
    [SerializeField] protected Color usedColor;
    [SerializeField] protected Color rendedOutColor;
    [SerializeField] protected int maxUpgradeLevel = 10;
    [SerializeField] protected int minUpgradeLevel = 0;
    [SerializeField] protected float upgradePercent = 0.2f;
    [SerializeField] public WeaponDataSO weaponDataSO;
    [SerializeField] public WeaponData weaponData;

    protected const string useString = "Used";
    protected const string rendedOutString = "Rended Out";

    protected void Start()
    {
        InitWeaponData();
        RegisterOnClickEvent();
    }

    protected void InitWeaponData()
    {
        if (weaponDataSO == null) return;

        weaponData.weaponImage = weaponDataSO.weaponImage;
        weaponData.weaponName = weaponDataSO.weaponName;
        weaponData.damage = weaponDataSO.damage;
        weaponData.dispersion = weaponDataSO.dispersion;
        weaponData.rateOfFire = weaponDataSO.rateOfFire;
        weaponData.reloadSpeed = weaponDataSO.reloadSpeed;
        weaponData.ammunition = weaponDataSO.ammunition;
        weaponData.magazine = weaponDataSO.magazine;
        weaponData.upgrade = weaponDataSO.upgrade;
    }

    protected void RegisterOnClickEvent()
    {
        if (button == null) return;

        button.onClick.AddListener(() => { OnClick(); });
    }

    protected void OnClick()
    {
        WeaponButtonManager.Instance.SetCurrentWeaponButton(this);

        if (WeaponButtonManager.Instance.previousWeaponButton != null)
        {
            DisableSelectPanel(WeaponButtonManager.Instance.previousWeaponButton);
        }

        if (WeaponButtonManager.Instance.currentWeaponButton != null)
        {
            EnableSelectPanel(WeaponButtonManager.Instance.currentWeaponButton);
        }

        WeaponButtonManager.Instance.previousWeaponButton = WeaponButtonManager.Instance.currentWeaponButton;

        if (weaponState != WeaponState.None)
        {
            PrimaryWeaponPanel.Instance.ChangeButtonTextToDisableColor();
        }
        else
        {
            PrimaryWeaponPanel.Instance.ChangeButtonTextToNormalColor();
        }

        ShowDecription();
        ShowWeaponImage();
    }

    public void SetNoneWeapon()
    {
        if (textGameObject == null) return;

        SetWeaponState(WeaponState.None);
        DisableText(textGameObject);
    }

    public void SetUsedWeapon()
    {
        if (textGameObject == null) return;

        if (weaponState == WeaponState.Used || weaponState == WeaponState.RendedOut) return;

        if (WeaponButtonManager.Instance.usedWeaponButton != null) 
        { 
            WeaponButtonManager.Instance.usedWeaponButton.SetNoneWeapon();
        }

        WeaponButtonManager.Instance.usedWeaponButton = this;
        PrimaryWeaponPanel.Instance.ChangeButtonTextToDisableColor();

        SetWeaponState(WeaponState.Used);
        EnableText(textGameObject);
        SetText(useString);
        SetTextColor(usedColor);
    }

    public void SetRendedOutWeapon()
    {
        if (textGameObject == null) return;

        if (weaponState == WeaponState.Used || weaponState == WeaponState.RendedOut) return;

        PrimaryWeaponPanel.Instance.ChangeButtonTextToDisableColor();

        SetWeaponState(WeaponState.RendedOut);
        EnableText(textGameObject);
        SetText(rendedOutString);
        SetTextColor(rendedOutColor);
    }

    public void UpgradeWeapon()
    {
        if (weaponDataSO == null) return;
        if (weaponData.upgrade >= maxUpgradeLevel) return;

        weaponData.damage += (int)(weaponDataSO.damage * upgradePercent);
        weaponData.dispersion += (int)(weaponDataSO.dispersion * upgradePercent);
        weaponData.rateOfFire += (int)(weaponDataSO.rateOfFire * upgradePercent);
        weaponData.reloadSpeed += 10;
        weaponData.ammunition += (int)(weaponDataSO.ammunition * upgradePercent);
        weaponData.magazine += (int)(weaponDataSO.magazine * upgradePercent);
        weaponData.upgrade += 1;

        ShowDecription();
    }

    public void DowngradeWeapon()
    {
        if (weaponDataSO == null) return;
        if (weaponData.upgrade <= minUpgradeLevel) return;

        weaponData.damage -= (int)(weaponDataSO.damage * upgradePercent);
        weaponData.dispersion -= (int)(weaponDataSO.dispersion * upgradePercent);
        weaponData.rateOfFire -= (int)(weaponDataSO.rateOfFire * upgradePercent);
        weaponData.reloadSpeed -= 10;
        weaponData.ammunition -= (int)(weaponDataSO.ammunition * upgradePercent);
        weaponData.magazine -= (int)(weaponDataSO.magazine * upgradePercent);
        weaponData.upgrade -= 1;

        ShowDecription();
    }

    protected void ShowDecription()
    {
        if (weaponData == null) return;

        WeaponDecriptionPanel.Instance.SetDecription(weaponData);
    }

    protected void ShowWeaponImage()
    {
        if (weaponData == null) return;

        PrimaryWeaponPanel.Instance.SetWeaponImage(weaponData);
    }

    public void EnableSelectPanel(WeaponButton weaponButton)
    {
        if (weaponButton.selectedPanel == null) return;

        weaponButton.selectedPanel.SetActive(true);
    }

    public void DisableSelectPanel(WeaponButton weaponButton)
    {
        if (weaponButton.selectedPanel == null) return;

        weaponButton.selectedPanel.SetActive(false);
    }

    protected void SetWeaponState(WeaponState state)
    {
        weaponState = state;
    }

    protected void EnableText(GameObject textObject)
    {
        textObject.SetActive(true);
    }

    protected void DisableText(GameObject textObject)
    {
        textObject.SetActive(false);
    }

    protected void SetText(string text)
    {
        if (weaponStateText == null) return;

        weaponStateText.text = text;
    }

    protected void SetTextColor(Color color)
    {
        if (weaponStateText == null) return;

        weaponStateText.color = color;
    }
}

public enum WeaponState
{
    None,
    Used,
    RendedOut
}

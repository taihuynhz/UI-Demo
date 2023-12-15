using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] protected WeaponState state = WeaponState.None;
    [SerializeField] protected GameObject glowingPanel;
    [SerializeField] protected Text stateText;
    [SerializeField] public Toggle toggle;
    [SerializeField] protected Color usedColor;
    [SerializeField] protected Color rendedOutColor;
    [SerializeField] public WeaponData data;

    protected const string UsedString = "Used";
    protected const string RendedOutString = "Rended Out";

    protected void Start()
    {
        RegisterOnValueChangedEvent();
    }

    protected void RegisterOnValueChangedEvent()
    {
        toggle.onValueChanged.AddListener( toggle => { OnValueChanged(); } );
    }

    public void OnValueChanged()
    {
        if (toggle.isOn)
        {
            glowingPanel.SetActive(true);
            CheckStateToggleOn();
            WeaponManager.Instance.SelectWeapon(this);
            WeaponDecriptionPanel.Instance.SetDecription(data);
            PrimaryWeaponPanel.Instance.SetWeaponImage(data);          
        }
        else
            glowingPanel.SetActive(false);
    }

    protected void CheckStateToggleOn()
    {
        if (state == WeaponState.None)
        {
            PrimaryWeaponPanel.Instance.ChangeButtonTextToNormalColor();
            PrimaryWeaponPanel.Instance.ChangeUseButtonText("Use");
            PrimaryWeaponPanel.Instance.ChangeRentButtonText("Rent Out");
        }

        if (state == WeaponState.Used)
        {
            PrimaryWeaponPanel.Instance.ChangeRentOutButtonToDisableColor();
            PrimaryWeaponPanel.Instance.ChangeUseButtonText("Un-use");
            PrimaryWeaponPanel.Instance.ChangeRentButtonText("Rent Out");
        }

        if (state == WeaponState.RendedOut)
        {
            PrimaryWeaponPanel.Instance.ChangeButtonTextToNormalColor();
            PrimaryWeaponPanel.Instance.ChangeUseButtonText("Use");
            PrimaryWeaponPanel.Instance.ChangeRentButtonText("Un-rent");
        }
    }

    public void SetNoneWeapon()
    {
        state = WeaponState.None;
        stateText.gameObject.SetActive(false);
    }

    public void SetUseWeapon()
    {
        if (state == WeaponState.Used)
            UnUseWeapon();
        else
        {
            UseWeapon();
            PrimaryWeaponPanel.Instance.ChangeRentOutButtonToDisableColor();

            Weapon anotherUsedWeapon = WeaponManager.Instance.weaponList[WeaponManager.Instance.weaponUsedID];
            if (anotherUsedWeapon.state == WeaponState.Used && anotherUsedWeapon.data.ID != this.data.ID)
            {
                anotherUsedWeapon.SetNoneWeapon();
            }
            WeaponManager.Instance.weaponUsedID = data.ID;
        }
    }

    public void SetRentWeapon()
    {
        if (state == WeaponState.Used) return;

        if (state == WeaponState.RendedOut)
            UnRentWeapon();
        else
            RentWeapon();
    }

    protected void UseWeapon()
    {
        if (state == WeaponState.RendedOut) 
            PrimaryWeaponPanel.Instance.ChangeRentButtonText("Rent Out");

        state = WeaponState.Used;
        stateText.text = UsedString;
        stateText.color = usedColor;
        stateText.gameObject.SetActive(true);
        PrimaryWeaponPanel.Instance.ChangeUseButtonText("Un-use");
    }

    protected void UnUseWeapon()
    {
        PopupPanel.Instance.ShowPopupPanel();
        PopupPanel.Instance.SetPopupPanelText(PopupPanelText.UnUse);
        PopupPanel.yesAction = SetNoneWeapon;
        PopupPanel.yesAction += PrimaryWeaponPanel.Instance.ChangeButtonTextToNormalColor;
        PopupPanel.yesAction += () => PrimaryWeaponPanel.Instance.ChangeUseButtonText("Use");
    }

    protected void RentWeapon()
    {
        state = WeaponState.RendedOut;
        stateText.text = RendedOutString;
        stateText.color = rendedOutColor;
        stateText.gameObject.SetActive(true);
        PrimaryWeaponPanel.Instance.ChangeRentButtonText("Un-rent");
    }

    protected void UnRentWeapon()
    {
        PopupPanel.Instance.ShowPopupPanel();
        PopupPanel.Instance.SetPopupPanelText(PopupPanelText.UnRent);
        PopupPanel.yesAction = SetNoneWeapon;
        PopupPanel.yesAction += PrimaryWeaponPanel.Instance.ChangeButtonTextToNormalColor;
        PopupPanel.yesAction += () => PrimaryWeaponPanel.Instance.ChangeRentButtonText("Rent Out");
    }

    public void UpgradeWeapon()
    {
        WeaponData defaultData = WeaponManager.Instance.weaponDataSO.weaponDatas[data.ID];

        data.damage += (int) (defaultData.damage * data.upgradePercent);
        data.dispersion += (int) (defaultData.dispersion * data.upgradePercent);
        data.rateOfFire += (int) (defaultData.rateOfFire * data.upgradePercent);
        data.reloadSpeed += 10;
        data.ammunition += (int) (defaultData.ammunition * data.upgradePercent);
        data.upgradeLevel++;

        PopupPanel.Instance.ShowPopupLog(PopupLog.Upgrade);
        WeaponDecriptionPanel.Instance.SetDecription(data);
    }

    public void DowngradeWeapon()
    {
        WeaponData defaultData = WeaponManager.Instance.weaponDataSO.weaponDatas[data.ID];

        data.damage -= (int) (defaultData.damage * data.upgradePercent);
        data.dispersion -= (int) (defaultData.dispersion * data.upgradePercent);
        data.rateOfFire -= (int) (defaultData.rateOfFire * data.upgradePercent);
        data.reloadSpeed -= 10;
        data.ammunition -= (int) (defaultData.ammunition * data.upgradePercent);
        data.upgradeLevel--;

        PopupPanel.Instance.ShowPopupLog(PopupLog.Downgrade);
        WeaponDecriptionPanel.Instance.SetDecription(data);
    }
}

public enum WeaponState
{
    None,
    Used,
    RendedOut
}

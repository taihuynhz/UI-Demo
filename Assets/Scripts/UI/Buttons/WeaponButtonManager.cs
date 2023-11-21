using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButtonManager : Singleton<WeaponButtonManager>
{
    [Header("Weapon Button Manager")]
    [SerializeField] public WeaponButton usedWeaponButton;
    [SerializeField] public WeaponButton previousWeaponButton;
    [SerializeField] public WeaponButton currentWeaponButton;
    [SerializeField] protected GameObject weaponButtonPrefab;
    [SerializeField] protected Transform contentTransform;
    [SerializeField] protected WeaponDataSO[] weaponDatas;

    protected void Reset()
    {
        LoadWeaponDatas();
    }

    protected void Start()
    {
        LoadWeaponDatas();
        InitWeaponButton();
    }

    protected void LoadWeaponDatas()
    {
        weaponDatas = Resources.LoadAll<WeaponDataSO>("Datas/Weapon Datas");
    }

    protected void InitWeaponButton()
    {
        if (weaponDatas == null) return;

        for (int i = 0; i < weaponDatas.Length; i++)
        {
            GameObject newWeaponButton = Instantiate(weaponButtonPrefab, contentTransform);
            newWeaponButton.name = weaponDatas[i].weaponName; 
            newWeaponButton.GetComponent<WeaponButton>().weaponDataSO = weaponDatas[i];
        }
    }

    public void SetCurrentWeaponButton(WeaponButton weaponButton)
    {
        currentWeaponButton = weaponButton;
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : Singleton<WeaponManager>
{
    [Header("Weapon Manager")]
    [SerializeField] public Weapon selectedWeapon;
    [SerializeField] public ToggleGroup toggleGroup;
    [SerializeField] protected Transform contentTransform;
    [SerializeField] protected Weapon weaponPrefab;
    [SerializeField] public WeaponDataSO weaponDataSO;
    [SerializeField] public List<Weapon> weaponList;
    [HideInInspector] public int weaponUsedID;

    protected void Start()
    {
        InitWeapon();
        ShowFirstWeaponInfoOnStart();
    }

    protected void InitWeapon()
    {
        for (int i = 0; i < weaponDataSO.weaponDatas.Count; i++)
        {
            Weapon newWeapon = Instantiate(weaponPrefab, contentTransform);

            newWeapon.data = new WeaponData(weaponDataSO.weaponDatas[i]);
            newWeapon.toggle.group = toggleGroup;
            weaponList.Add(newWeapon);
        }
        SelectWeapon(weaponList[0]);
    }

    public void ShowFirstWeaponInfoOnStart()
    {
        selectedWeapon.toggle.isOn = true;
        selectedWeapon.OnValueChanged();
    }

    public void SelectWeapon(Weapon weapon)
    {
        selectedWeapon = weapon;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData
{
    public Sprite weaponImage;
    public string weaponName;
    public int ID;
    public int damage;
    public int dispersion;
    public int rateOfFire;
    public int reloadSpeed;
    public int ammunition;
    public int upgradeLevel;
    public int maxUpgradeLevel = 10;
    public int minUpgradeLevel = 0;
    public float upgradePercent = 0.2f;

    public WeaponData(WeaponData data)
    {
        weaponImage = data.weaponImage;
        weaponName = data.weaponName;
        ID = data.ID;
        damage = data.damage;
        dispersion = data.dispersion;
        rateOfFire = data.rateOfFire;
        reloadSpeed = data.reloadSpeed;
        ammunition = data.ammunition;
        upgradeLevel = data.upgradeLevel;
        maxUpgradeLevel = data.maxUpgradeLevel;
        minUpgradeLevel = data.minUpgradeLevel;
        upgradePercent = data.upgradePercent;
    }
}

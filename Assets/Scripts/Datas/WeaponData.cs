using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData
{
    [Header("Weapon Data")]
    public Sprite weaponImage;
    public string weaponName;
    public int damage;
    public int dispersion;
    public int rateOfFire;
    public int reloadSpeed;
    public int ammunition;
    public int magazine;
    public int upgrade;
}

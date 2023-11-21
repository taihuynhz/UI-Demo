using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    public Sprite weaponImage;
    public string weaponName = "Weapon 1";
    [Range(0, 1000)]
    public int damage = 25;
    [Range(0, 1000)]
    public int dispersion = 5;
    [Range(0, 1000)]
    public int rateOfFire = 600;
    [Range(0, 1000)]
    public int reloadSpeed = 0;
    [Range(0, 1000)]
    public int ammunition = 100; 
    [Range(0, 1000)]
    public int magazine = 100;
    [Range(0, 10)]
    public int upgrade = 0;

    protected void Awake()
    {
        weaponName = name;
    }
}

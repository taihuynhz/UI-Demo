using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    public List<WeaponData> weaponDatas;
}

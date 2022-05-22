using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponBaseConfig> allWeapons = new List<WeaponBaseConfig>();

    private void Awake()
    {
        if (allWeapons.Count == 0)
        {
            allWeapons = Resources.LoadAll<WeaponBaseConfig>("Weapon").ToList();
        }
    }
    
    private void Reset()
    {
        allWeapons = Resources.LoadAll<WeaponBaseConfig>("Weapon").ToList();
    }

    public List<WeaponBaseConfig> GetAllWeapons()
    {
        return allWeapons;
    }

    public void ChangeWeaponByName(string weaponName)
    {
        GameEvents.current.WeaponChangeTrigger(allWeapons.SingleOrDefault(w => w.name == weaponName));
    }
    
}
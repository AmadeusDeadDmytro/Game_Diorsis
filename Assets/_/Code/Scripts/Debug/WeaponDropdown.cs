using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDropdown : MonoBehaviour
{
    private WeaponManager _weaponManager;
    private TMP_Dropdown _dropdown;
    
    private void Start()
    {
        _dropdown = transform.GetComponent<TMP_Dropdown>();
        _weaponManager = GameObject.FindWithTag("Weapon Manager").GetComponent<WeaponManager>();
    }

    public void ChangePlayerWeapon()
    {
        int value = _dropdown.value;
        _weaponManager.ChangeWeaponByName(_dropdown.options[value].text);
    }
}
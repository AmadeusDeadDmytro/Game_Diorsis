using System;
using UnityEngine;

public class GameEvents: MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public delegate void WeaponChangeAction(WeaponBaseConfig weapon);

    public event WeaponChangeAction onWeaponChange;

    public void WeaponChangeTrigger(WeaponBaseConfig weapon)
    {
        if (onWeaponChange != null)
        {
            onWeaponChange(weapon);
        }
    }
}
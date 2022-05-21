using System;
using UnityEngine;

public class GameEvents: MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onWeaponChange;

    public void WeaponChangeTrigger()
    {
        if (onWeaponChange != null)
        {
            onWeaponChange();
        }
    }
}
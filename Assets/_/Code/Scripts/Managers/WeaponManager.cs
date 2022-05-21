using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Player player;
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
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        allWeapons = Resources.LoadAll<WeaponBaseConfig>("Weapon").ToList();
    }

    private void Start()
    {
        GameEvents.current.onWeaponChange += OnWeaponChange;
    }


    private void OnWeaponChange()
    {
        Debug.Log("event");
    }
}
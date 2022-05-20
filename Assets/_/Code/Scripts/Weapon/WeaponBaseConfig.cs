using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New weapon",menuName = "Diorsis Assets/Weapon")]
public class WeaponBaseConfig: ScriptableObject
{
    public string weaponName;
    public WeaponType type;
    public AnimatorController animationController;
}
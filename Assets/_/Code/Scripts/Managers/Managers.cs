using UnityEngine;

public class Managers : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private InputManager inputManager;

    [Header("Objects")] 
    [SerializeField] private Player player;

    private void Update()
    {
        inputManager.CheckPress(player);
    }
}
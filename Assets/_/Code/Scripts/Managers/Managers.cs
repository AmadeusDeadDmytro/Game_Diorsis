using UnityEngine;

public class Managers : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private InputManager inputManager;

    [Header("Objects")] 
    [SerializeField] private Player player;
    [SerializeField] private Animator playerAnimator;

    private void Update()
    {
        inputManager.Movement(player, playerAnimator);
    }
}
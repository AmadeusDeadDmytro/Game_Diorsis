using UnityEngine;

public class PlayerAnimationEvents: MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private InputManager inputManager;
    
    public void CancelFlip()
    {
        player.FlipCancel();
        inputManager.UnblockInput();
    }
}
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float playerRunSpeed = 5.0f;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    public void Movement(Player player, Animator animator)
    {
        float horizontalInputValue = Input.GetAxisRaw("Horizontal");
        if (horizontalInputValue != 0)
        {
            // Flip player
            player.IsFlip(horizontalInputValue < 0);
            
            // Move Character
            float moveValue = horizontalInputValue * playerRunSpeed * Time.deltaTime;
            player.transform.Translate(Vector3.right * moveValue);
        }
        
        // Change Animation
        animator.SetBool(IsRunning, horizontalInputValue != 0);
    }
}

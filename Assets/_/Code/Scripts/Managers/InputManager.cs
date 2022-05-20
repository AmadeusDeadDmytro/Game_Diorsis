using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    private bool _isBlocked = false;
    private Animator _playerAnimator;

    public void CheckPress(Player player)
    {
        if (!_playerAnimator)
        {
            _playerAnimator = player.transform.GetChild(0).GetComponent<Animator>();
        }
        
        if (_isBlocked) return;

        float horizontalInputValue = Input.GetAxisRaw("Horizontal");
        if (horizontalInputValue != 0)
        {
            player.Movement(horizontalInputValue);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isBlocked = true;
            player.Flip();
        }

        // Change Animation
        _playerAnimator.SetBool(IsRunning, horizontalInputValue != 0);
    }

    public void UnblockInput()
    {
        _isBlocked = false;
    }
}

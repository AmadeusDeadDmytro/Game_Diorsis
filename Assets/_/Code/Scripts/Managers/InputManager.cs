using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2D;

    public void Movement(Player player)
    {
        if (!_playerRigidbody2D) InitPlayerRigidbody(player);

        float horizontalInputValue = Input.GetAxisRaw("Horizontal");
        if (horizontalInputValue != 0)
        {
            
        }
    }

    private void InitPlayerRigidbody(Player player)
    {
        _playerRigidbody2D = player.transform.GetComponent<Rigidbody2D>();
    }
}

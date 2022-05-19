using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float playerRunSpeed = 5.0f;
    
    private Rigidbody2D _playerRigidbody2D;

    public void Movement(Player player)
    {
        if (!_playerRigidbody2D) InitPlayerRigidbody(player);

        float horizontalInputValue = Input.GetAxisRaw("Horizontal");
        if (horizontalInputValue != 0)
        {
            float moveValue = horizontalInputValue * playerRunSpeed * Time.deltaTime;
            player.transform.Translate(Vector3.right * moveValue);
        }
    }

    private void InitPlayerRigidbody(Player player)
    {
        _playerRigidbody2D = player.transform.GetComponent<Rigidbody2D>();
    }
}

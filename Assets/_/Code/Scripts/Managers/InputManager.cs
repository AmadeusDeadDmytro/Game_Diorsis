using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float playerRunSpeed = 5.0f;

    public void Movement(Player player)
    {
        float horizontalInputValue = Input.GetAxisRaw("Horizontal");
        if (horizontalInputValue != 0)
        {
            float moveValue = horizontalInputValue * playerRunSpeed * Time.deltaTime;
            player.transform.Translate(Vector3.right * moveValue);
        }
    }
}

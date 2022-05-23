using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float playerRunSpeed = 5.0f;
    [SerializeField] private float playerFlipSpeed = 7.0f;
    
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    [Header("Settings")] 
    [SerializeField] private WeaponType currentWeapon = WeaponType.None;
    [SerializeField] private float airDivider = 2.0f;

    [Header("Rays")] 
    [SerializeField] private GameObject rayPositionLeft;
    [SerializeField] private GameObject rayPositionRight;

    private static readonly int IsFlipping = Animator.StringToHash("isFlipping");
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameEvents.current.onWeaponChange += SetCurrentWeapon;
    }

    public void Movement(float horizontalValue)
    {
        bool isLeftDirection = horizontalValue < 0;
        
        // Flip player
        IsFlip(isLeftDirection);
        
        // Check if wall in front of player
        if (IsWallInFront(isLeftDirection)) return;

        // Decrease horizontal speed if player in the air
        float speed = _rigidbody.velocity.y < 0 ? playerRunSpeed / airDivider : playerRunSpeed;

        // Move Character
        float moveValue = horizontalValue * speed * Time.deltaTime;
        transform.Translate(Vector3.right * moveValue);
    }

    public void Flip()
    {
        animator.SetBool(IsFlipping, true);
        
        // Move Character
        _rigidbody.AddForce(Vector2.right * (spriteRenderer.flipX ? -playerFlipSpeed : playerFlipSpeed), ForceMode2D.Impulse);
    }

    public void FlipCancel()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = 0.0f;
        animator.SetBool(IsFlipping, false);
    }

    private bool IsWallInFront(bool isLeft)
    {
        RaycastHit2D hit = isLeft
            ? Physics2D.Raycast(rayPositionLeft.transform.position, Vector2.left) 
            : Physics2D.Raycast(rayPositionRight.transform.position, Vector2.right);

        if (hit.collider == null) return false;
        float startRayX = isLeft
            ? rayPositionLeft.transform.position.x
            : rayPositionRight.transform.position.x;

        float distance = Mathf.Abs(hit.point.x - startRayX);
        return distance <= 0.0f;
    }

    private void SetCurrentWeapon(WeaponBaseConfig weapon)
    {
        currentWeapon = weapon.type;
        animator.runtimeAnimatorController = weapon.animationController;
    }

    private void IsFlip(bool value)
    {
        spriteRenderer.flipX = value;
    }
}
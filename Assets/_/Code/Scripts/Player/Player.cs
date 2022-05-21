using System;
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
    [SerializeField] private AnimatorController defaultController;

    [Header("Settings")] [SerializeField] 
    private WeaponType currentWeapon = WeaponType.None;
    
    private static readonly int IsFlipping = Animator.StringToHash("isFlipping");
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Movement(float horizontalValue)
    {
        // Flip player
        IsFlip(horizontalValue < 0);
            
        // Move Character
        float moveValue = horizontalValue * playerRunSpeed * Time.deltaTime;
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

    public void SetCurrentWeapon(WeaponBaseConfig weapon)
    {
        if (!weapon)
        {
            currentWeapon = WeaponType.None;
            animator.runtimeAnimatorController = defaultController;
            return;
        }
        
        currentWeapon = weapon.type;
        animator.runtimeAnimatorController = weapon.animationController;
    }

    private void IsFlip(bool value)
    {
        spriteRenderer.flipX = value;
    }
}
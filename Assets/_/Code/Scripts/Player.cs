using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void IsFlip(bool value)
    {
        spriteRenderer.flipX = value;
    }
}
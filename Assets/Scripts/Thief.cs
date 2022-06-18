using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Thief : MonoBehaviour
{
    [SerializeField] private int _speed;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public bool IsFalling { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.flipX = (transform.position.x < 0);

        _animator = GetComponent<Animator>();

        IsFalling = true;
        _animator.SetBool(ThiefAnimatorController.Params.IsFalling, IsFalling);
    }

    private void Update()
    {
        _animator.SetBool(ThiefAnimatorController.Params.IsFalling, IsFalling);

        if (IsFalling == false)
            transform.Translate((transform.position.x < 0 ? Vector2.left : Vector2.right) * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsFalling = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsFalling = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

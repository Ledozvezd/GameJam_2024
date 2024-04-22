using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtc : MonoBehaviour
{
    private bool _isAttacking = false;
    Animator _animator;
    SpriteRenderer _spriteRenderer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void StartAtc()
    {
        _isAttacking = false;
    }

    public void StopAtc()
    {
        _isAttacking = true;
    }

    private void OnTriggerStay2D(Collider2D collision) //ХП много снимает
    {
        
        if (collision.CompareTag("Player") && !_isAttacking)//&& !_isAttacking
        {
            if(_spriteRenderer.flipX) 
            {
                _animator.SetTrigger("AttackL");
            }
            else
            {
                _animator.SetTrigger("Attack");
            }
            Player.TakeDamage(5);
            StopAtc();
        }
    }
}

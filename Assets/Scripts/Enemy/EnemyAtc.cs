using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtc : MonoBehaviour
{
    Animator _animator;
    SpriteRenderer _spriteRenderer;

    private float timeBtwAttack = -1;
    private float timeStartAttack = 0.4f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision) //ХП много снимает
    {

        if (collision.CompareTag("Player"))//&& !_isAttacking
        {
            if (timeBtwAttack < 0)
            {
                if (_spriteRenderer.flipX)
                {
                    _animator.SetTrigger("AttackL");
                }
                else
                {
                    _animator.SetTrigger("Attack");
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void EnemyAttack()
    {
        Player.TakeDamage(5);
        timeBtwAttack = timeStartAttack;
    }
}

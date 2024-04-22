using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtc : MonoBehaviour
{
    private bool _isAttacking;
    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
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
        if (collision.CompareTag("Player") && !_isAttacking)
        {
            _animator.SetTrigger("Attack");
            Player.TakeDamage(5);
            StopAtc();
        }
    }
}

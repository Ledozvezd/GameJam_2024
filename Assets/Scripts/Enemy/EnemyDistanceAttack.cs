using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceAttack : MonoBehaviour
{
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    [SerializeField] GameObject _bullet;
    private float timeBtwAttack = -1;
    private float timeStartAttack = 2.2f;

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
                _animator.SetBool("Attack", true);
                Debug.Log("Atck");
                //timeBtwAttack = timeStartAttack;
        }
        else
        {
                _animator.SetBool("Attack", false);
            timeBtwAttack -= Time.deltaTime;
        }
    }
}

public void EnemyAttack()
{
        Debug.Log("Ins");
    //Player.TakeDamage(5);
    timeBtwAttack = timeStartAttack;
        Instantiate(_bullet, transform.parent.position, Quaternion.identity);
}
}
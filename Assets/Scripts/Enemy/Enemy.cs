using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 30;
    private float _speed = 4;
    private float _minDistance = 1f;
    private Vector2 _target;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [SerializeField] GameObject _death;
    [SerializeField] GameObject _sprite;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        _target = Player.GiveCoordinates();
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position.y > -0.81f)
        {
            transform.position = new Vector2(transform.position.x, -0.81f);
        }
        if(Mathf.Abs(transform.position.x - _target.x) < _minDistance)
        {
            _speed = 0;
        }
        else
        {
            _speed = 4;
        }
        if (_target.x - transform.position.x <= 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.61f);
    }

    public void Suffer(int damage)
    {
        _animator.SetTrigger("Damage");
        HP -= damage;
        Debug.Log("Àé þäÿüá!");
        if(HP < 0)
        {
            _death.SetActive(true);
            _sprite.SetActive(false);
        }
    }
}

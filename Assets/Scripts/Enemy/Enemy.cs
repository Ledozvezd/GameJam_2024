using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public int HP = 20;
    private float _speed = 1f;
    private Vector2 _target;

    Animator _animator;

    //private static Enemy instance;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        //instance = this;
    }

    void FixedUpdate()
    {
        _target = Player.GiveCoordinates() + new Vector2(-0.6f, 0.36f);
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void Suffer(int damage)
    {
        HP -= damage;
        Debug.Log("јй юд€ьб!");
        if(HP < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //„ерез Event сделать
    {
        if(collision.CompareTag("Player")) 
        {
            _animator.SetTrigger("Attack");
            Player.TakeDamage(10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    private int HP = 15;
    private float _speed = 1f;
    private Vector2 _target;

    //private static Enemy instance;

    void Start()
    {
        //instance = this;
    }

    void FixedUpdate()
    {
        _target = Player.GiveCoordinates();
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
            Player.TakeDamage(10);
        }
    }
}

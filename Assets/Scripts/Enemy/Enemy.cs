using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    private int HP = 30;
    private float _speed = 1.5f;
    private Vector2 _target;

    void Start()
    {
    }

    void FixedUpdate()
    {
        _target = Player.GiveCoordinates();
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void Suffer(int damage)
    {
        HP -= damage;
        Debug.Log("Àé þäÿüá!");
        if(HP < 0)
        {
            Destroy(gameObject);
        }
    }
}

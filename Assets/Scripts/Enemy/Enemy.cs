using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public int HP = 25;
    private float _speed = 4;
    private Vector2 _target;

    void FixedUpdate()
    {
        _target = Player.GiveCoordinates();
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position.y > -0.81f)
        {
            transform.position = new Vector2(transform.position.x, -0.81f);
        }
        if(Mathf.Abs(transform.position.x - _target.x) < 1f)
        {
            //Debug.Log("So close!");
            //transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            _speed = 0;
        }
        else
        {
            _speed = 4;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.61f);
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

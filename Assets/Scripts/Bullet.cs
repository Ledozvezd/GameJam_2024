using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 4f;
    private Vector2 _target;

    void Update()
    {
        //Debug.Log("Sta");
        _target = Player.GiveCoordinates();
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position.y > -0.81f)
        {
            transform.position = new Vector2(transform.position.x, -0.81f);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -0.61f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shield"))//&& !_isAttacking
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))//&& !_isAttacking
        {
            Player.TakeDamage(5);
            Destroy(gameObject);
        }

        //Destroy(gameObject);
    }
}

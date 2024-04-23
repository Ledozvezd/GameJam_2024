using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _movementSpeed = 0f;

    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _music;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] GameObject _gameObject;

    private Rigidbody2D _rb;
    private Attack _attack;
    private float X;
    private float Y;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _attack = GetComponentInChildren<Attack>();
    }

    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(X, Y);

        if (moveDirection != Vector2.zero)
        {
            Move(moveDirection);
            _animator.SetBool("isRunning", true);
            _music.Play();
        }
        else
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);
            _music.Stop();
        }
    }

    private void Move(Vector2 direction)
    {
        if(_attack.isAttacking) 
        {
            return;
        }
        if (direction.x < 0)
        {
            _sprite.flipX = true;
            _gameObject.transform.rotation = Quaternion.Euler(new Vector2(0,180f));
        }
        else
        {
            _sprite.flipX = false;
            _gameObject.transform.rotation = Quaternion.Euler(new Vector2(0, 0f));
        }
        ApplyVelocity(direction);
    }

    private void ApplyVelocity(Vector2 desiredVelocity)
    {
        var velocity = _rb.velocity;

        velocity.x = desiredVelocity.x * _movementSpeed;
        velocity.y = desiredVelocity.y * _movementSpeed;

        _rb.velocity = velocity;
    }
}



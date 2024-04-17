using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _movementSpeed = 0f;
    //[SerializeField] public float _dashSpeed = 0f;
    //[SerializeField] private AnimationCurve _dashSpeedCurve;
    //[SerializeField] private float _dashTime = 0.2f;

    //[SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;

    private Rigidbody2D _rb;
    private Attack _attack;
    private bool _isDashing;
    private float X;
    private float Y;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _attack = GetComponentInChildren<Attack>();
    }

    private void Update()
    {
        //_animator.SetBool("isDashing", _isDashing);

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(X, Y);

        if (moveDirection != Vector2.zero)
        {
            Move(moveDirection);
            //_animator.SetBool("isRunning", true);
            //_music.Play();
        }
        else
        {
            _rb.velocity = Vector2.zero;
            //_animator.SetBool("isRunning", false);
            //_music.Stop();
        }

        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash(moveDirection));
        }
        */

    }

    private void Move(Vector2 direction)
    {
        //if (_isDashing) return;
        if(_attack.isAttacking)
        {
            return;
        }
        if (direction.x < 0)
        {
            _sprite.flipX = false;
            _attack.transform.position = new Vector2(-1.6f,0.7f);
        }
        else
        {
            _sprite.flipX = true;
            _attack.transform.position = new Vector2(1.6f, 0.7f);
        }
        

        ApplyVelocity(direction);
    }

    /*private IEnumerator Dash(Vector3 direction)
    {
        if (direction == Vector3.zero) yield break;
        if (_isDashing) yield break;

        _isDashing = true;

        var elapsedTime = 0.0f;
        while (elapsedTime < _dashTime)
        {
            var velocityMultiplier = _dashSpeed * _dashSpeedCurve.Evaluate(elapsedTime);
            ApplyVelocity(direction, velocityMultiplier);

            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _isDashing = false;
        yield break;
    }*/

    private void ApplyVelocity(Vector2 desiredVelocity)
    {
        var velocity = _rb.velocity;

        velocity.x = desiredVelocity.x * _movementSpeed;
        velocity.y = desiredVelocity.y * _movementSpeed;

        _rb.velocity = velocity;
    }
}



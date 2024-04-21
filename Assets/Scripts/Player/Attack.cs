using System.Collections;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator _playerAnim;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _sprite;
    [SerializeField] private AudioSource _music;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _size;
    [SerializeField] private LayerMask _layerMask;
    
    private float _timeBtwAtck = -1.0f;
    private float startTimeBtwAtck = 0.23f;

    public bool isAttacking { get; private set; } //Хзшка, багов без него нет, а с ним время от времени ГГ не может ходить

    void Update()
    {
        //Debug.Log(isAttacking);
        if (_timeBtwAtck < 0)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                //Debug.Log(isAttacking);
                if (_spriteRenderer.flipX)
                {
                    _playerAnim.SetTrigger("AttackL");
                }
                else
                {
                    _playerAnim.SetTrigger("AttackR");
                }
                _timeBtwAtck = startTimeBtwAtck;
                _music.Play();
                AttackHim();
                //isAttacking = true;
            }
        }
        else
        {
           //isAttacking = false;
            _timeBtwAtck -= Time.deltaTime;
            //_sprite.transform.position = Vector2.zero;
        }
    }

    // Make Attack Script   for Player                  
        

    public void AttackHim()//Fix it
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _size, _layerMask);
            foreach (Collider2D c in enemies)
            {
                c.GetComponent<Enemy>().Suffer(Player.myDamage);
            }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(_attackPoint.position, _size);
    }
}
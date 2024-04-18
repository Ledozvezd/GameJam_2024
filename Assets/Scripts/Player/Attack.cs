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

    private float _timeBtwAtck = -1.0f;
    private float startTimeBtwAtck = 0.23f;

    public bool isAttacking { get; private set; }

    void Update() //Тут через сферу и войд атак всё заделать. Реф есть
    {
        if (Input.GetMouseButtonDown(0) && _timeBtwAtck < 0) 
        {
            
            if(_spriteRenderer.flipX)
            {
                _playerAnim.SetTrigger("AttackL");
            }
            else
            {
                _playerAnim.SetTrigger("AttackR");
            }
            _timeBtwAtck = startTimeBtwAtck;
            _music.Play();
            StartCoroutine(AttackHim());
        }
        else
        {
            isAttacking = false;
            _sprite.transform.position = Vector2.zero;
        }

        if(_timeBtwAtck >= 0){
            _timeBtwAtck -= Time.deltaTime;
            //isAttacking = true;
            
        }
        else
        {
            //isAttacking = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && isAttacking)
        {
            other.GetComponent<Enemy>().Suffer(Player.myDamage);
        }
    }

    private IEnumerator AttackHim()
    {
        yield return null;
    }
}
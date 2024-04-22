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
    Collider2D[] enemies;

    public bool isAttacking;// { get; private set; } //Хзшка, багов без него нет, а с ним время от времени ГГ не может ходить

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
                //AttackHim();
                //isAttacking = true;
            }
        }
        else
        {
            _timeBtwAtck -= Time.deltaTime;
            //_sprite.transform.position = Vector2.zero;
        }
    }                 
        
    public void StartAtack()//Fix it OverlapCircleAll - работает только на вход TriggerStay мб
    {
        isAttacking = true;
    }

    public void EndAttack()
    {
       isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && isAttacking)
        {
            enemies = collision.GetComponents<Collider2D>();
            foreach (var item in enemies)
            {
                item.GetComponent<Enemy>().Suffer(5);
            }
        }
    }
}
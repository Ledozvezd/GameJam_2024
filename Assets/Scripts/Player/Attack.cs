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
    private float startTimeBtwAtck = 0.5f;
    Collider2D[] enemies;

    private float _timeBtwBlock = -1.0f;
    private float startTimeBtwBlock = 1.0f;
    public bool isAttacking;// { get; private set; } //Хзшка, багов без него нет, а с ним время от времени ГГ не может ходить

    void Update()
    {
        if (Input.GetMouseButton(1)) //Input.GetMouseButton(1)
        {
            if (_timeBtwBlock < 0) //_timeBtwBlock < 0
            {
                Player.isInvul = true;
                _playerAnim.SetTrigger("Block");
                _timeBtwBlock = startTimeBtwBlock;
            }
        }
        else
        {
            Player.isInvul = false;
            _timeBtwBlock -= Time.deltaTime;
        }
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

    public void StartBlock()
    {
        Player.isInvul = true;
    }

    public void EndBlock()
    {
        Player.isInvul = false;
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

    //public void AttackIt()
    //{
       // Collider2D.
    //}
}
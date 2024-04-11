using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator _playerAnim;

    private float _timeBtwAtck = -1.0f;
    private float startTimeBtwAtck = 0.45f;

    public bool isAttacking { get; private set; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _timeBtwAtck < 0) 
        {
            _playerAnim.SetTrigger("Attack");
            _timeBtwAtck = startTimeBtwAtck;
            Debug.Log("Attc");
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
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
}
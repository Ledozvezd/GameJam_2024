using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //[SerializeField] private Animator _playerAnim;
    //[SerializeField] private AudioSource _source;

    private float _timeBtwAtck = -1.0f;
    public float startTimeBtwAtck = 0.56f;

    public bool isAttacking { get; private set; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _timeBtwAtck < 0) 
        {
            //_playerAnim.SetTrigger("Attack");
            _timeBtwAtck = startTimeBtwAtck;
        }

        if(_timeBtwAtck >= 0){
            _timeBtwAtck -= Time.deltaTime;
            isAttacking = true;
            
        }
        else
        {
            isAttacking = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && isAttacking)
        {
            Destroy(other.gameObject);
        }
    }
}
using System.Runtime.CompilerServices;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //[SerializeField] private Animator _playerAnim;
    //[SerializeField] private AudioSource _source;

    private float _timeBtwAtck;
    public float startTimeBtwAtck = 0.56f;

    public bool isAttacking { get { return isAttacking; } private set { } }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _timeBtwAtck <= 0)
        {
            //_playerAnim.SetTrigger("Attack");
            _timeBtwAtck = startTimeBtwAtck;
            isAttacking = true;
            Debug.Log("Attack");
        }
        else
        {
            _timeBtwAtck -= Time.deltaTime;
            isAttacking = false;
        }
    }
}
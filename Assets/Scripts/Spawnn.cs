using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] _enmemies;
    [SerializeField] int[] _amountEnemies;
    [SerializeField] Vector3[] _position;

    int temp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        temp = _position.Length;
        if(collision.CompareTag("Player"))
        {
            for (int i = 0; i < _amountEnemies[0]; i++)
            {
                temp = _position.Length;
                temp = Random.Range(0, temp);
                GameObject.Instantiate(_enmemies[0], _position[temp] + transform.position, Quaternion.identity);
            }  
            /*for (int i = 0; i < _amountEnemies[1]; i++)
            {
                temp = _position.Length;
                temp = Random.Range(0, temp);
                GameObject.Instantiate(_enmemies[1], _position[temp], Quaternion.identity);
            }   
            for (int i = 0; i < _amountEnemies[2]; i++)
            {
                temp = _position.Length;
                temp = Random.Range(0, temp);
                GameObject.Instantiate(_enmemies[2], _position[temp], Quaternion.identity);
            }*/
        }
    }
}

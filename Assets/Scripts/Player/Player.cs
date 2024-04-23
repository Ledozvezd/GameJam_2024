using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static int _health = 100;
    public static int myDamage = 5;
    public static bool isInvul;
    public Vector3 position;
    [SerializeField] Slider _slider;

    public static void TakeDamage(int enemyDamage)
    {
        if (isInvul)
        {
            Debug.Log("Задефал");
            return;
        }
        _health -= enemyDamage;
        if( _health <= 0 )
        {
            Debug.Log("Вы мертв!");
        }
    }

    public static Vector2 GiveCoordinates()
    {
        return instance.transform.position;
    }

    private void Start()
    {
        instance = this;
    }
    public void Heal(int health)
    {
        _health += health;
        if (_health > 100)
        {
            _health = 100;
        }
    }
    private void Update()
    {
        _slider.value = _health;
    }

}

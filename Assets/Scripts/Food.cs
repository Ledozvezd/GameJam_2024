using UnityEngine;

public class Loot : MonoBehaviour
{
    //private float _fade = 10f;
    private bool _isFade = false;
    public int loot = 20;
    private Color _color;

    void Start()
    {
        _color = GetComponent<Color>();
    }
    private void Update()
    {
        if (_isFade)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().Heal(loot);
            _isFade = true;
        }
    }
}

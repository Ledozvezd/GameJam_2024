using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject _loot;
    void Start()
    {
        //Random random = new Random();
        StartCoroutine(KillTimer());
    }

    private IEnumerator KillTimer()
    {
        yield return new WaitForSeconds(0.3f);
        //Random random = new Random();]
        if(Random.Range(0,100) > 75)
        {
            Instantiate(_loot, _parent.transform.position + new Vector3(0f, -0.2f, 0f), Quaternion.identity);
        }
        //Instantiate(_loot, _parent.transform.position + new Vector3(0f, -0.2f, 0f), Quaternion.identity);
        Destroy(_parent);

    }
}


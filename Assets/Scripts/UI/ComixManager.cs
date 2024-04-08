using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ComixManager : MonoBehaviour
{
    [SerializeField] public GameObject[] images;
    public int i = 0;
    public void Start()
    {
        DOTween.Init();
    }
    public void Update()
    {
        if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {
            images[i].SetActive(true);
            i++;
            if( i > images.Length - 1)
            {
                SceneManager.LoadScene("Level");
            }
        }
    }
}

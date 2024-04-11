using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ComixManager : MonoBehaviour
{
    [SerializeField] public Image[] images;
    private int i = 1;
    private void Start()
    {
        DOTween.Init(true);
    }
    private void Update()
    {
        images[0].DOColor(new Color(1, 1, 1, 1.0f), 1.5f);
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            images[i].DOColor(new Color(1, 1, 1, 1.0f), 1.5f);
            i++;
            if (i > images.Length - 1)
            {
                LoadManager.SwitchToScene("Level");
            }
        }
    }
}
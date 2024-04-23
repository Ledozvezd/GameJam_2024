using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

public class ComixManager : MonoBehaviour
{
    [SerializeField] public Image[] images;
    [SerializeField] private GameObject _LoadManager;
    private int i = 0;
    private bool flag = true;
    private void Start()
    {
        DOTween.Init(true);
        _LoadManager.SetActive(true);
    }
    private void Update() // Переписать логику, что i стартовое 0 или сделать фейд адекватный, на 0 пока не работает
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (flag)
            {
                if (i + 1 >= images.Length)
                {
                    images[i].gameObject.SetActive(true);
                    images[i].DOColor(new Color(0, 0, 0, 0.0f), 0.5f);
                    images[i].gameObject.SetActive(false);
                    _LoadManager.SetActive(true);
                    LoadManager.SwitchToScene("StartVideo");
                    flag = false;
                }
                else
                {
                    images[i].DOColor(new Color(0, 0, 0, 0.0f), 0.5f);
                    images[i].gameObject.SetActive(false);
                    i++;
                    images[i].gameObject.SetActive(true);
                    images[i].DOColor(new Color(1, 1, 1, 1.0f), 1.5f);
                }
            }
        }
    }
}

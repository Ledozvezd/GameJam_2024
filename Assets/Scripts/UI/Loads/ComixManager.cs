using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

public class ComixManager : MonoBehaviour
{
    [SerializeField] public Image[] images;
    private int i = 0;
    private void Start()
    {
        DOTween.Init(true);
        //images[0].DOColor(new Color(1, 1, 1, 1.0f), 1.5f);
    }
    private void Update() // ���������� ������, ��� i ��������� 0 ��� ������� ���� ����������, �� 0 ���� �� ��������
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(i + " Before Fade");
            i--;
            images[i].DOColor(new Color(0, 0, 0, 0.0f), 0.5f);
            Debug.Log(i + " After Fade");
            i += 1;
            images[i].DOColor(new Color(1, 1, 1, 1.0f), 1.5f);
            i++;
            Debug.Log(i + " After Fade out");
            if (i > images.Length - 1)
            {
                LoadManager.SwitchToScene("Level");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Scene_Intro : MonoBehaviour
{
    public VideoPlayer vid;
    [SerializeField] private string _sceneName;

    void Start() { vid.loopPointReached += CheckOver; }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(_sceneName);
    }

}

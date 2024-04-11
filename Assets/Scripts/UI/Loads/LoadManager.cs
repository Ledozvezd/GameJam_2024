using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private Animator _animator;
    private static bool _shouldPlayOpen;

    private static LoadManager instance;
    private AsyncOperation _loadingOperation;
    public static void SwitchToScene(string sceneName)
    {
        instance._animator.SetTrigger("Start");
        Debug.Log("Switch");
        instance._loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        instance._loadingOperation.allowSceneActivation = false;
    }
    void Start()
    {
        instance = this;
        _animator = GetComponent<Animator>();

        if (_shouldPlayOpen) _animator.SetTrigger("End");
        Debug.Log("Start");
    }

    public void AnimationOver() 
    {
        Debug.Log("Over");
        //Debug.Log()
        _shouldPlayOpen = true;
        _loadingOperation.allowSceneActivation = true;
    }
}

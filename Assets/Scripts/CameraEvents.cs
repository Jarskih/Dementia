using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraEvents : MonoBehaviour
{
    private CameraFade _fade;
    private void Start()
    {
        _fade = FindObjectOfType<CameraFade>();
    }
    private void OnEnable()
    {
        EventManager.StartListening("EndGame", EndGame);
        EventManager.StartListening("StartGame", FadeOut);
    }

    private void OnDisable()
    {
        EventManager.StopListening("EndGame", EndGame);
        EventManager.StartListening("StartGame", FadeOut);
    }
    
    private void EndGame()
    {
        FadeIn();
        StartCoroutine(ChangeScene());
    }
    
    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Cinematic");
    }

    private void FadeIn()
    {
        _fade.FadeIn();
    }

    private void FadeOut()
    {
        _fade.FadeOut();
    }
}

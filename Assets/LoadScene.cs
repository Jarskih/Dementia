using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] private string _scene;

    private void OnEnable()
    {
        EventManager.StartListening("EndGame", LoadNextScene);
    }

    private void OnDisable()
    {
        EventManager.StopListening("EndGame", LoadNextScene);
    }

    private void LoadNextScene()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_scene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableAfterSeconds : MonoBehaviour
{
    [SerializeField] private int _disableAfterSeconds = 3;
    void Start()
    {
        Invoke(nameof(Disable), _disableAfterSeconds);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableAfterSeconds : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(Disable), 3);
    }

    void Disable()
    {
        GetComponent<Image>().enabled = false;
    }
}

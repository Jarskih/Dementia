using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour
{
    private Image _image;
    private bool _fadeIn;
    private float _speed = 0.5f;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if (_fadeIn)
        {
            if (_image.color.a < 1)
            {
                var color = _image.color;
                color.a += Time.deltaTime * _speed;
                _image.color = color;
            }
        }
        else
        {
            if (_image.color.a > 0)
            {
                var color = _image.color;
                color.a -= Time.deltaTime * _speed;
                _image.color = color;
            }
        }
    }

    public void FadeOut()
    {
        _fadeIn = false;
    }

    public void FadeIn()
    {
        _fadeIn = true;
    }
}

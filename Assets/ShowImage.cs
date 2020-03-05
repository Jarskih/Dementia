using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{

    [SerializeField] private string _eventName;
    [SerializeField] private int delay = 6;
    private int counter = 0;

    private bool showImage;
    private Image _image;

    private void OnEnable()
    {
        EventManager.StartListening(_eventName, ImageVisible());
    }

    private void OnDisable()
    {
        EventManager.StopListening(_eventName, ImageVisible());
    }

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _image.enabled = false;
    }
    
    private void ImageVisible()
    {
        showImage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!showImage)
        {
            return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class WalkSound : MonoBehaviour
{
    private Animator _anim;

    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_anim.GetFloat("PlayerVelocity") > 0)
        {
            if (!_source.isPlaying)
            {
                _source.Play(); 
            }
        }
        else
        {
            _source.Stop();
        }
    }
}

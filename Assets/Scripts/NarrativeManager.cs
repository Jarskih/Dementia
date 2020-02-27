using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] private float _textDelay = 3f;
    [SerializeField] private List<Conversation> _conversations = new List<Conversation>();
    [SerializeField] private List<Narrative> _narratives = new List<Narrative>();

    private float _textTimer;

    private Conversation _currentConversation;

    [SerializeField]
    private TextMeshProUGUI _uiText;

    private void Start()
    {
        foreach (var c in _conversations)
        {
            c.Reset();
        }
    }

    private void Update()
    {
        if (_currentConversation != null)
        {
            _textTimer += Time.deltaTime;

            if (_textTimer < _textDelay)
            {
                return;
            }
            _uiText.text = _currentConversation.GetNextLine().line;
            _textTimer = 0;
            return;
        }

        _uiText.text = "";
    }

    private void OnEnable()
    {
        EventManager.StartListening("AfterCrash", AfterCrash);
        EventManager.StartListening("PhoneBooth", PhoneBooth);
    }

    private void OnDisable()
    {
        EventManager.StopListening("AfterCrash", AfterCrash);
        EventManager.StopListening("PhoneBooth", PhoneBooth);
    }

    private void PhoneBooth()
    {
         _currentConversation = FindConversation("PhoneBooth"); 
    }

    private void AfterCrash()
    {
        _currentConversation = FindConversation("AfterCrash");   
    }

    private Conversation FindConversation(string id)
    {
        foreach (var c in _conversations)
        {
            if (c.conversationId == id)
            {
                return c;
            }
        }
        return null;
    }
}

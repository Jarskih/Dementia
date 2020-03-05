using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] private float _textDelay = 3f;
    [SerializeField] private List<Conversation> _conversations = new List<Conversation>();

    private float _textTimer;

    private Conversation _currentConversation;

    [SerializeField]
    private TextMeshProUGUI _uiText;

    [SerializeField] private GameObject _ui;

    private void Start()
    {
        foreach (var c in _conversations)
        {
            c.Reset();
        }

        if (_ui == null || _uiText == null)
        {
            Debug.LogError("Assign missing UI elements");
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

            _ui.SetActive(true);
            var narrative = _currentConversation.GetNextLine();
            if (narrative == null)
            {
                _currentConversation = null;
                return;
            }

            _uiText.text = narrative.GetLine();
            _textTimer = 0;
            return;
        }

        _ui.SetActive(false);
        _uiText.text = "";
    }

    private void OnEnable()
    {
        // Triggers
        EventManager.StartListening("AfterCrash", AfterCrash);
        EventManager.StartListening("Wallet", Wallet);
        EventManager.StartListening("Fountain", Fountain);
        EventManager.StartListening("PoliceTalksToDaughter", PoliceTalksToDaughter);
        EventManager.StartListening("DiscussionWithDaughter", DiscussionWithDaughter);
        EventManager.StartListening("PoliceChat", PoliceChat);
        
        // Item events
        EventManager.StartListening("FoundWallet", FoundWallet);
        EventManager.StartListening("FoundCoins", FoundCoins);
        EventManager.StartListening("PhoneCall", PhoneCall);
        EventManager.StartListening("FoundPhoneBooth", FoundPhoneBooth); 
        EventManager.StartListening("FoundCoinOnly", FoundCoinOnly); 
        EventManager.StartListening("PhoneBoothWalletOnly", PhoneBoothWalletOnly); 
        EventManager.StartListening("PhoneBoothCoinOnly", PhoneBoothCoin); 
    }

    private void OnDisable()
    {
        EventManager.StopListening("AfterCrash", AfterCrash);
        EventManager.StopListening("Wallet", Wallet);
        EventManager.StopListening("Fountain", Fountain);
        EventManager.StopListening("PoliceTalksToDaughter", PoliceTalksToDaughter);
        EventManager.StopListening("DiscussionWithDaughter", DiscussionWithDaughter);
        EventManager.StopListening("PoliceChat", PoliceChat);

        EventManager.StopListening("FoundWallet", FoundWallet);
        EventManager.StopListening("FoundCoins", FoundCoins);
        EventManager.StopListening("PhoneCall", PhoneCall);
        EventManager.StopListening("FoundPhoneBooth", FoundPhoneBooth);
        EventManager.StopListening("FoundCoinOnly", FoundCoinOnly); 
        EventManager.StopListening("PhoneBoothWalletOnly", PhoneBoothWalletOnly); 
        EventManager.StopListening("PhoneBoothCoinOnly", PhoneBoothCoin); 
    }
    
    private void PhoneBoothCoin()
    {
        _currentConversation = FindConversation("PhoneBoothCoinOnly");
        _textTimer = 10;
    }

    private void PhoneBoothWalletOnly()
    {
        _currentConversation = FindConversation("PhoneBoothWalletOnly");
        _textTimer = 10;
    }

    private void FoundCoinOnly()
    {
        _currentConversation = FindConversation("FoundCoinOnly");
        _textTimer = 10;
    }
    
    private void PoliceChat()
    {
        _currentConversation = FindConversation("PoliceChat");
        _textTimer = 10;
    }

    
    private void DiscussionWithDaughter()
    {
        _currentConversation = FindConversation("DiscussionWithDaughter");
        _textTimer = 10;
    }

    private void PoliceTalksToDaughter()
    {
        _currentConversation = FindConversation("PoliceTalksToDaughter");
        _textTimer = 10;
    }

    private void FoundWallet()
    {
        _currentConversation = FindConversation("FoundWallet"); 
        _textTimer = 10;
    }

    private void PhoneCall()
    {
         _currentConversation = FindConversation("PhoneCall"); 
         _textTimer = 10;
    }

    private void FoundPhoneBooth()
    {
        _currentConversation = FindConversation("FoundPhoneBooth"); 
        _textTimer = 10;
    }

    private void AfterCrash()
    {
        _currentConversation = FindConversation("AfterCrash");   
        _textTimer = 10;
    }
    private void Fountain()
    {
        _currentConversation = FindConversation("Fountain");
        _textTimer = 10;
    }
    
    private void Wallet()
    {
        _currentConversation = FindConversation("Wallet");
        _textTimer = 10;
    }
    
    private void FoundCoins()
    {
        _currentConversation = FindConversation("FoundCoins");
        _textTimer = 10;
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

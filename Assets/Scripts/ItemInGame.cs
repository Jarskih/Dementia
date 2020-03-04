using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInGame : MonoBehaviour, IInteractable
{
    [SerializeField] private Item _item;
    [SerializeField] private string eventName;

    public Item PickUp()
    {
        if (eventName != "")
        {
            EventManager.TriggerEvent(eventName);    
        }
        return _item;
    }
}

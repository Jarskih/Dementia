using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private Inventory _inventory;
    private Collider2D playerCollider;
    [SerializeField] private Image _ui;
    private IInteractable _item;
    private bool _pickUp;
    private GameObject _itemObject;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        _inventory = GetComponent<Inventory>();
        _ui.enabled = false;
    }

    private void Update()
    {
        if (_item == null)
        {
            _ui.enabled = false;
            return;
        }
        else
        {
            _ui.enabled = true;
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            _inventory.AddItem(_item.PickUp());
            Debug.Log("Picked Up: " + _item.PickUp().itemName);
            Destroy(_itemObject);
            _ui.enabled = false;
            _item = null;
            _itemObject = null;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (_item == null)
        {
            _item = other.GetComponent<IInteractable>();
            _itemObject = other.gameObject;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private Inventory _inventory;
    private UIPickUpButton _pickUpButtonImage;
    private IInteractable _item;
    private bool _pickUp;
    private GameObject _itemObject;

    void Start()
    {
        _inventory = GetComponent<Inventory>();
        _pickUpButtonImage = FindObjectOfType<UIPickUpButton>();
        _pickUpButtonImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_item == null)
        {
            _pickUpButtonImage.gameObject.SetActive(false);
            return;
        }
        else
        {
            _pickUpButtonImage.gameObject.SetActive(true);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            _inventory.AddItem(_item.PickUp());
            Debug.Log("Picked Up: " + _item.PickUp().itemName);
            Destroy(_itemObject);
            _pickUpButtonImage.enabled = false;
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

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
    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        _inventory = GetComponent<Inventory>();
        _ui.enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var item = other.GetComponent<IInteractable>();
        if(item == null) return;

        _ui.enabled = true;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventory.AddItem(item.PickUp());
            Debug.Log("Picked Up: " + item.PickUp().itemName);
            Destroy(other.gameObject);
            _ui.enabled = false;
        }
    }
}

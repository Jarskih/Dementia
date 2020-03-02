using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UInvetoryItem : MonoBehaviour
{
    private Inventory _inventory;
    [SerializeField] private Item _itemType;

    private bool _active;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        var images = GetComponentsInChildren<UnityEngine.UI.Image>();
        foreach (var i in images)
        {
            i.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_active) return;
        
        if(_inventory.HasItem(_itemType))
        {
            var images = GetComponentsInChildren<UnityEngine.UI.Image>();

            foreach (var i in images)
            {
                i.enabled = true;
            }

            _active = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();
    
    void AddItem(Item item)
    {
        if (_items.Contains(item)) return;
        _items.Add(item);
    }

    public bool HasItem(Item item)
    {
        return _items.Contains(item);
    }
}

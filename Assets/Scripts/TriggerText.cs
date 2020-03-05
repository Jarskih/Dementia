using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class TriggerText : MonoBehaviour
{
    [SerializeField] private bool played;
    [SerializeField] private List<Item> _requiredItems = new List<Item>();
    [SerializeField] private List<Item> _itemsShouldNotBeFound = new List<Item>();
    [SerializeField] private string textId;
    [SerializeField] private float radius = 1;
    [SerializeField] private bool playAtStart;

    private CircleCollider2D _col;

    private void Start()
    {
        _col = GetComponent<CircleCollider2D>();
        _col.radius = radius;

        if (playAtStart)
        {
            played = true;
            Debug.Log("Trigger: " + textId);
            EventManager.TriggerEvent(textId);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInteract>() == null)
        {
            return;
        }
        

        if (played)
        {
            return;
        }

        if (!HasRequiredItems(other.GetComponent<Inventory>()))
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            if (CanSkip(other.GetComponent<Inventory>()))
            {
                return;
            }

            played = true;
            Debug.Log("Trigger: " + textId);
            EventManager.TriggerEvent(textId);
        }
    }

    private bool CanSkip(Inventory i)
    {
        if (_itemsShouldNotBeFound.Count == 0)
        {
            return false;
        }
        
        bool value = false;

        foreach (var item in _itemsShouldNotBeFound)
        {
            value = i.HasItem(item);
        }

        return value;
    }

    private bool HasRequiredItems(Inventory i)
    {
        if (_requiredItems.Count == 0)
        {
            return true;
        }
        
        bool value = false;

        foreach (var item in _requiredItems)
        {
            value = i.HasItem(item);
        }

        return value;
    }

    private void OnDrawGizmos()
    {
        if (played)
        {
            Gizmos.color = Color.white;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

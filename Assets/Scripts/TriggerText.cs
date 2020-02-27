using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerText : MonoBehaviour
{
    private bool played;
    [SerializeField] private List<Item> _requiredItems = new List<Item>();
    [SerializeField] private string textId;
    [SerializeField] private float radius = 1;

    private CircleCollider2D _col;

    private void Start()
    {
        _col = GetComponent<CircleCollider2D>();
        _col.radius = radius;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
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
            played = true;
            EventManager.TriggerEvent(textId);
        }
    }

    private bool HasRequiredItems(Inventory i)
    {
        bool value = false;

        foreach (var item in _requiredItems)
        {
            value = i.HasItem(item);
        }

        return value;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

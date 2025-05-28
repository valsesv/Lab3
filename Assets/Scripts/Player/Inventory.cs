using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _inventoryText;
    [HideInInspector] public List<string> _inventoryObjects = new List<string>();

    private void Awake()
    {
        UpdateInventoryText();
    }

    public void AddItem(InventoryObject item)
    {
        _inventoryObjects.Add(item.ObjectName);
        UpdateInventoryText();
    }

    public void RemoveItem(string itemName)
    {
        _inventoryObjects.Remove(itemName);
        UpdateInventoryText();
    }

    public bool HasItem(string itemName)
    {
        return _inventoryObjects.Contains(itemName);
    }

    private void UpdateInventoryText()
    {
        _inventoryText.text = "INVENTORY:\n\n";
        foreach (var item in _inventoryObjects)
        {
            _inventoryText.text += item + "\n";
        }
    }
}
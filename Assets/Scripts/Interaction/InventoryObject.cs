using UnityEngine;

public class InventoryObject : MonoBehaviour, IInteractable
{
    [SerializeField] private string _objectName;
    private Inventory _inventory;

    public string ObjectName => _objectName;

    private void Start()
    {
        _inventory = FindFirstObjectByType<Inventory>();
    }

    public void Interact()
    {
        _inventory.AddItem(this);
        Destroy(gameObject);
    }
}
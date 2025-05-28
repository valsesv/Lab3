using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private NotifPanel _notifPanel;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private SimpleFPS _player;
    [SerializeField] private string _keyName;

    public void Interact()
    {
        if (_inventory.HasItem(_keyName) == false)
        {
            _notifPanel.ShowNotif("Locked");
            return;
        }

        _winPanel.SetActive(true);
        _player.enabled = false;
    }
}
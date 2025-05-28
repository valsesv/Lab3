using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 3f;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    [SerializeField] private GameObject _interactionUI;

    private IInteractable _interactable;

    private void Start()
    {
        _interactionUI.SetActive(false);
    }

    private void Update()
    {
        UpdateInteractable();
        TryInteract();
    }

    private void TryInteract()
    {
        if (Input.GetKeyDown(_interactionKey) == false)
        {
            return;
        }
        if (_interactable == null)
        {
            return;
        }

        _interactable.Interact();
    }

    private void UpdateInteractable()
    {
        Ray ray = _playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, _interactionDistance) == false)
        {
            _interactable = null;
            _interactionUI.SetActive(false);
            return;
        }

        var interactable = hit.collider.GetComponent<IInteractable>();
        if (interactable == _interactable)
        {
            return;
        }

        SetInteractable(interactable);
    }

    private void SetInteractable(IInteractable interactable)
    {
        _interactable = interactable;
        _interactionUI.SetActive(interactable != null);
    }
}
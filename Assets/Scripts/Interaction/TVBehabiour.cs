using TMPro;
using UnityEngine;

public class TVBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private SafeBehavior _safe;
    [SerializeField] private GameObject _screenObject;
    [SerializeField] private TextMeshPro _codeDisplay;

    private void Start()
    {
        _screenObject.SetActive(false);
        _codeDisplay.text = _safe.Code;
    }

    public void Interact()
    {
        _screenObject.SetActive(!_screenObject.activeSelf);
    }
}
using UnityEngine;

public class SafeBehavior : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _safeDoor;
    [SerializeField] private CodeInputController _codeInputController;
    [SerializeField] private SimpleFPS _player;
    private bool _isInteracting = false;
    private string _code;

    public string Code => _code;

    private void Awake()
    {
        const string chars = "0123456789";
        _code = "";
        for (int i = 0; i < 4; i++)
        {
            _code += chars[Random.Range(0, chars.Length)];
        }
        _codeInputController.gameObject.SetActive(_isInteracting);
        _codeInputController.SetSafeBehavior(this);
    }

    public void Interact()
    {
        _isInteracting = !_isInteracting;

        _codeInputController.gameObject.SetActive(_isInteracting);
        _player.enabled = !_isInteracting;
    }

    public bool EnterCode(string code)
    {
        return code == _code;
    }
}
using UnityEngine;

public class SafeBehavior : MonoBehaviour, IInteractable
{
    private string _code;

    public string Code => _code;

    private void Awake()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        _code = "";
        for (int i = 0; i < 4; i++)
        {
            _code += chars[Random.Range(0, chars.Length)];
        }
    }

    public void Interact()
    {
        Debug.Log("Interact with Safe");
    }
}
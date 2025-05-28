using UnityEngine;

public class TVBehaviour : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interact with TV");
    }
}
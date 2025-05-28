using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    [SerializeField] private bool _lockCursorOnStart = true;
    [SerializeField] private bool _hideCursorOnStart = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (_lockCursorOnStart)
        {
            LockCursor();
        }
        else
        {
            UnlockCursor();
        }

        if (_hideCursorOnStart)
        {
            HideCursor();
        }
        else
        {
            ShowCursor();
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void ToggleCursor()
    {
        if (Cursor.visible)
        {
            HideCursor();
            LockCursor();
        }
        else
        {
            ShowCursor();
            UnlockCursor();
        }
    }
}
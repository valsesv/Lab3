using TMPro;
using UnityEngine;

public class NotifPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _notifText;
    [SerializeField] private float _timeToHide = 3f;
    private float _currentTimeToHide;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowNotif(string message)
    {
        _notifText.text = message;
        gameObject.SetActive(true);
        _currentTimeToHide = _timeToHide;
    }

    private void Update()
    {
        _currentTimeToHide -= Time.deltaTime;
        if (_currentTimeToHide <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
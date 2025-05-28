using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeInputController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _codeDisplay;
    [SerializeField] private Button[] _digitsButtons;
    [SerializeField] private Button _clearButton;
    [SerializeField] private Button _enterButton;
    [SerializeField] private int _codeLength;

    private SafeBehavior _safeBehavior;

    public void SetSafeBehavior(SafeBehavior safeBehavior)
    {
        _safeBehavior = safeBehavior;
    }

    private void Awake()
    {
        foreach (var digitButton in _digitsButtons)
        {
            digitButton.onClick.AddListener(() => OnDigitButtonClick(digitButton));
        }

        _clearButton.onClick.AddListener(OnClearButtonClick);
        _enterButton.onClick.AddListener(OnEnterButtonClick);

        OnClearButtonClick();
    }

    void OnDestroy()
    {
        foreach (var digitButton in _digitsButtons)
        {
            digitButton.onClick.RemoveAllListeners();
        }

        _clearButton.onClick.RemoveAllListeners();
        _enterButton.onClick.RemoveAllListeners();
    }

    private void OnEnterButtonClick()
    {
        if (_safeBehavior.EnterCode(_codeDisplay.text) == false)
        {
            _codeDisplay.text = "Wrong";
        }
    }

    private void OnClearButtonClick()
    {
        _codeDisplay.text = "";
    }

    private void OnDigitButtonClick(Button digitButton)
    {
        if (_codeDisplay.text == "Wrong")
        {
            _codeDisplay.text = "";
        }

        if (_codeDisplay.text.Length >= _codeLength)
        {
            return;
        }

        _codeDisplay.text += digitButton.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
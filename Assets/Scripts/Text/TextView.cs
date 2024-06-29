using System;
using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI showText;

    private void OnEnable()
    {
        TextController.onTextTriggered += ShowText;
    }

    private void OnDisable()
    {
        TextController.onTextTriggered -= ShowText;
    }

    private void ShowText(string text)
    {
        showText.text = text;
    }
}

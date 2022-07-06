using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Material bodyHighMaterial;
    [SerializeField] private Material bodyLowMaterial;
    [SerializeField] private Button changeCharacterColorButton;
    [SerializeField] private Button changeBackgroundButton;
    [SerializeField] private Material backgroundMaterial;

    private void Awake()
    {
        changeCharacterColorButton.onClick.AddListener(OnClickChangeCharacterColor);
        changeBackgroundButton.onClick.AddListener(OnClickChangeBackgroundColor);
    }

    private void OnClickChangeCharacterColor()
    {
        bodyHighMaterial.color = new Color(Random.value, Random.value, Random.value);
        bodyLowMaterial.color = new Color(Random.value, Random.value, Random.value);
    }

    private void OnClickChangeBackgroundColor()
    {
        backgroundMaterial.color = new Color(Random.value, Random.value, Random.value);
    }
}

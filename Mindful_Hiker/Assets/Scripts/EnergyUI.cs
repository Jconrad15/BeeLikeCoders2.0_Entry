using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    [SerializeField]
    private AttributeBarUI attributeBar;

    private void Start()
    {
        Energy e = FindAnyObjectByType<Energy>();
        e.RegisterOnEnergyChanged(OnEnergyChanged);

        OnEnergyChanged(e.EnergyAmount);
    }

    private void OnEnergyChanged(int amount)
    {
        float percentage = amount / 100f;
        attributeBar.UpdateBarUI(percentage);
    }
}

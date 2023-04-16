using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private Action<int> cbOnEnergyChanged;

    private int energyAmount = 50;
    public int EnergyAmount
    {
        get => energyAmount;
        private set
        {
            if (value >= 100)
            {
                value = 100;
            }

            energyAmount = value;
            cbOnEnergyChanged?.Invoke(energyAmount);
        }
    }

    public void IncreaseEnergy(int amount)
    {
        EnergyAmount += amount;
    }

    public void DecreaseEnergy(int amount)
    {
        EnergyAmount -= amount;
    }

    public void RegisterOnEnergyChanged(Action<int> callbackfunc)
    {
        cbOnEnergyChanged += callbackfunc;
    }

    public void UnregisterOnEnergyChanged(Action<int> callbackfunc)
    {
        cbOnEnergyChanged -= callbackfunc;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relaxation : MonoBehaviour
{
    private Action<int> cbOnRelaxationChanged;

    private int relaxationAmount = 75;
    public int RelaxationAmount
    {
        get => relaxationAmount;
        private set
        {
            if (value >= 100)
            {
                value = 100;
            }

            relaxationAmount = value;
            cbOnRelaxationChanged?.Invoke(relaxationAmount);
        }
    }

    public void IncreaseRelaxation(int amount)
    {
        RelaxationAmount += amount;
    }

    public void DecreaseRelaxation(int amount)
    {
        RelaxationAmount -= amount;
    }

    public void RegisterOnRelaxationChanged(Action<int> callbackfunc)
    {
        cbOnRelaxationChanged += callbackfunc;
    }

    public void UnregisterOnRelaxationChanged(Action<int> callbackfunc)
    {
        cbOnRelaxationChanged -= callbackfunc;
    }
}

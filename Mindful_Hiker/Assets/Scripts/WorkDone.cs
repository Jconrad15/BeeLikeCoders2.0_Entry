using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkDone : MonoBehaviour
{

    private Action<int> cbOnAmountDoneChanged;

    private int amountDone;
    public int AmountDone
    {
        get => amountDone;
        private set
        {
            if (value >= 100)
            {
                value = 100;
            }

            amountDone = value;
            cbOnAmountDoneChanged?.Invoke(amountDone);
        }
    }

    private void Start()
    {
        AmountDone = 40;
    }

    public void IncreaseWorkDone(int amount)
    {
        AmountDone += amount;
    }

    public void DecreaseWorkDone(int amount)
    {
        AmountDone -= amount;
    }

    public void RegisterOnAmountDoneChanged(Action<int> callbackfunc)
    {
        cbOnAmountDoneChanged += callbackfunc;
    }

    public void UnregisterOnAmountDoneChanged(Action<int> callbackfunc)
    {
        cbOnAmountDoneChanged -= callbackfunc;
    }

}

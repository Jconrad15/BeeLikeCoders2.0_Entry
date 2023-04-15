using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{

    public int EnergyAmount { get; private set; } = 0;

    public void IncreaseEnergy(int amount)
    {
        EnergyAmount += amount;
    }

    public void DecreaseEnergy(int amount)
    {
        EnergyAmount -= amount;
    }

}

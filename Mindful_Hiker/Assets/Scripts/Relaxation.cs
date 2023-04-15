using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relaxation : MonoBehaviour
{
    public int RelaxationAmount { get; private set; } = 0;

    public void IncreaseRelaxation(int amount)
    {
        RelaxationAmount += amount;
    }

    public void DecreaseRelaxation(int amount)
    {
        RelaxationAmount -= amount;
    }


}

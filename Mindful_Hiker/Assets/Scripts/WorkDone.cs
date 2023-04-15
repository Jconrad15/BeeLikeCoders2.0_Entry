using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkDone : MonoBehaviour
{

    public int AmountDone { get; private set; } = 0;

    public void IncreaseWorkDone(int amount)
    {
        AmountDone += amount;
    }

    public void DecreaseWorkDone(int amount)
    {
        AmountDone -= amount;
    }


}

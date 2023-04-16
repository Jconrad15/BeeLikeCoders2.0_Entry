using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkDoneUI : MonoBehaviour
{
    [SerializeField]
    private AttributeBarUI attributeBar;

    private void Start()
    {
        WorkDone wd = FindAnyObjectByType<WorkDone>();
        wd.RegisterOnAmountDoneChanged(OnWorkDoneChanged);

        OnWorkDoneChanged(wd.AmountDone);
    }

    private void OnWorkDoneChanged(int amount)
    {
        float percentage = amount / 100f;
        attributeBar.UpdateBarUI(percentage);
    }
}

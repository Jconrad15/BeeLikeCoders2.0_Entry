using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkDoneUI : MonoBehaviour
{
    [SerializeField]
    private AttributeBarUI attributeBar;

    private void Start()
    {
        FindAnyObjectByType<WorkDone>()
            .RegisterOnAmountDoneChanged(OnWorkDoneChanged);
    }

    private void OnWorkDoneChanged(int amount)
    {
        float percentage = amount / 100f;
        attributeBar.UpdateBarUI(percentage);
    }
}

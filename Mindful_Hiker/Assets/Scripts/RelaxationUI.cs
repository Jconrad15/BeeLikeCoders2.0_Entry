using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelaxationUI : MonoBehaviour
{
    [SerializeField]
    private AttributeBarUI attributeBar;

    private void Start()
    {
        Relaxation r = FindAnyObjectByType<Relaxation>();
        r.RegisterOnRelaxationChanged(OnRelaxationChanged);

        OnRelaxationChanged(r.RelaxationAmount);
    }

    private void OnRelaxationChanged(int amount)
    {
        float percentage = amount / 100f;
        attributeBar.UpdateBarUI(percentage);
    }
}

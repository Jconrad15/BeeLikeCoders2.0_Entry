using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelaxationUI : MonoBehaviour
{
    [SerializeField]
    private AttributeBarUI attributeBar;

    private void Start()
    {
        FindAnyObjectByType<Relaxation>()
            .RegisterOnRelaxationChanged(OnRelaxationChanged);
    }

    private void OnRelaxationChanged(int amount)
    {
        float percentage = amount / 100f;
        attributeBar.UpdateBarUI(percentage);
    }
}

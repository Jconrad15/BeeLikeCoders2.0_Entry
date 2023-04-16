using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeBarUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform barForeground;

    private readonly float maxWidth = 150;
    private readonly float staticHeight = 25;

    public void UpdateBarUI(float percentage)
    {
        float value = percentage * maxWidth;
        barForeground.sizeDelta = new Vector2(value, staticHeight);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeBarUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform barForeground;

    private float maxWidth;
    private float staticHeight;

    private void Start()
    {
        maxWidth = barForeground.sizeDelta.x;
        staticHeight = barForeground.sizeDelta.y;
    }

    public void UpdateBarUI(float percentage)
    {
        float value = percentage * maxWidth;
        barForeground.sizeDelta = new Vector2(value, staticHeight);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{

    private float maxValue;
    private float currentValue;

    public Slider slider;
    public Image fill;
    public Gradient gradient;

    public void SetMaxValue(float maxInput)
    {
        maxValue = maxInput;
        currentValue = maxValue;
        slider.maxValue = maxValue;
        slider.value = currentValue;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(float valueInput)
    {
        currentValue = valueInput;
        slider.value = currentValue;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

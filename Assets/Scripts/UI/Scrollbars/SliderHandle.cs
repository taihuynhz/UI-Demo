using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandle : MonoBehaviour
{
    [Header("Slider Handle")]
    [SerializeField] protected ScrollRect scrollRect;
    [SerializeField] protected Slider slider;

    public void ChangeScrollHorizontalPosition()
    {
        if (scrollRect == null) return;

        scrollRect.horizontalNormalizedPosition = slider.value;
    }

    public void ChangeSliderValue()
    {
        if (slider == null) return;

        slider.value = scrollRect.horizontalNormalizedPosition;
    }
}
